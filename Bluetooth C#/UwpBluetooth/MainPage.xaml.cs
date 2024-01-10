using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;

namespace UwpBluetooth
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            RunAsync("20:68:9d:4c:12:29").Wait();
        }

        private async Task RunAsync(string deviceAddress)
        {
            try
            {
                try
                {
                    // Bluetooth-Adapter abrufen
                    var adapters = await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(BluetoothDevice.GetDeviceSelector());
                    var bluetoothAdapter = adapters.FirstOrDefault();

                    if (bluetoothAdapter == null)
                    {
                        Console.WriteLine("Bluetooth-Adapter nicht gefunden.");
                        return;
                    }

                    // Bluetooth-Gerät abrufen
                    var devices = await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(
                        BluetoothDevice.GetDeviceSelectorFromBluetoothAddress(ulong.Parse(deviceAddress.Replace(":", ""), System.Globalization.NumberStyles.HexNumber)),
                        null);

                    if (devices.Count == 0)
                    {
                        Console.WriteLine("Gerät nicht gefunden.");
                        return;
                    }

                    var bluetoothDevice = await BluetoothDevice.FromIdAsync(devices[0].Id);

                    // GATT-Client initialisieren
                    var gattDeviceService = await GattDeviceService.FromIdAsync(bluetoothDevice.DeviceId);

                    if (gattDeviceService == null)
                    {
                        Console.WriteLine("Konnte GATT-Service nicht öffnen.");
                        return;
                    }

                    // GATT-Characteristics abrufen
                    var characteristics = gattDeviceService.GetAllCharacteristics();

                    // Daten empfangen
                    foreach (var characteristic in characteristics)
                    {
                        var result = await characteristic.ReadValueAsync();
                        var reader = Windows.Storage.Streams.DataReader.FromBuffer(result.Value);
                        byte[] data = new byte[reader.UnconsumedBufferLength];
                        reader.ReadBytes(data);

                        // Hier kannst du mit den empfangenen Daten arbeiten
                        Console.WriteLine($"Empfangene Daten: {BitConverter.ToString(data)}");
                    }

                    // Verbindung trennen
                    gattDeviceService.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }
        }
    }
}
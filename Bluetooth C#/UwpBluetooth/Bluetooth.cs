using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Graphics.Printing;

namespace UwpBluetooth
{
    class Bluetooth
    {
/*
        public static void Main()
        {
            // Hier die Bluetooth-Adresse deines Geräts eintragen
            string deviceAddress = "20:68:9d:4c:12:29";

            Task.Run(() => RunAsync(deviceAddress)).Wait();

            Console.ReadLine();
        }
*/

        static async Task RunAsync(string deviceAddress)
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
    }
}

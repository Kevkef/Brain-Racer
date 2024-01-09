using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EEGData : MonoBehaviour
{

    #region Singleton

    public static EEGData instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Warning, several EEGData found!");
            return;
        }
        instance = this;
    }
    #endregion

    private int connectionID;
    public bool Connect()
    {
        int errCode = 0;
        NativeThinkGear thinkgear = new NativeThinkGear();

        /* Print driver version number */
        Debug.Log("Version: " + NativeThinkGear.TG_GetVersion());

        /* Get a connection ID handle to ThinkGear */
        connectionID = NativeThinkGear.TG_GetNewConnectionId();
        Debug.Log("Connection ID: " + connectionID);

        if (connectionID < 0)
        {
            Debug.Log("ERROR: TG_GetNewConnectionId() returned: " + connectionID);
            return false;
        }

        /* Attempt to connect the connection ID handle to serial port "COM5" (edit: changed to 4 based on my configurations)*/
        string comPortName = "\\\\.\\COM4";

        errCode = NativeThinkGear.TG_Connect(connectionID,
                      comPortName,
                      NativeThinkGear.Baudrate.TG_BAUD_1200, //may be changed to higher value (Baudrate)
                      NativeThinkGear.SerialDataFormat.TG_STREAM_PACKETS);
        if (errCode < 0)
        {
            Debug.Log("ERROR: TG_Connect() returned: " + errCode);
            return false;
        }
        return true;
    }

    public int[] readAttentionValues(int amount) {
        int errCode = 0;
        /* Read 10 ThinkGear Packets from the connection, 1 Packet at a time */
        int packetsRead = 0;
        int[] results = new int[amount];
        while (packetsRead < amount)
        {

            /* Attempt to read a Packet of data from the connection */
            errCode = NativeThinkGear.TG_ReadPackets(connectionID, 1);
            Debug.Log("TG_ReadPackets returned: " + errCode);
            /* If TG_ReadPackets() was able to read a complete Packet of data... */
            if (errCode == 1)
            {
                /* If attention value has been updated by TG_ReadPackets()... */
                if (NativeThinkGear.TG_GetValueStatus(connectionID, NativeThinkGear.DataType.TG_DATA_ATTENTION) != 0)
                {

                    /* Get and print out the updated attention value */
                    results[packetsRead] = (int)NativeThinkGear.TG_GetValue(connectionID, NativeThinkGear.DataType.TG_DATA_ATTENTION);
                    packetsRead++;

                } /* end "If attention value has been updated..." */

            } /* end "If a Packet of data was read..." */

        } /* end "Read 10 Packets of data from connection..." */
        return results;
    }

    public bool Disconnect() {
        try
        {
            NativeThinkGear.TG_Disconnect(connectionID); // disconnect test

            /* Clean up */
            NativeThinkGear.TG_FreeConnection(connectionID);
        }
        catch (Exception e)
        {
            Debug.Log("Error accured: " + e.ToString());
            return false;
        }
        return true;
    }
}

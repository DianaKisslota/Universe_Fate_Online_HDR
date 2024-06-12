using System.Collections.Generic;

public class DataSource : IDataSource
{
    private Dictionary<string, SectorData> _sectors = new Dictionary<string, SectorData>();
    public DataSource()
    {
        AddSector(new SectorMain0606(6, 6));
        AddSector(new SectorMain0607(6, 7));
        AddSector(new SectorMain0608(6, 8));
        AddSector(new SectorMain0609(6, 9));
        AddSector(new SectorMain0610(6, 10));
        AddSector(new SectorMain0611(6, 11));
        AddSector(new SectorMain0612(6, 12));
        AddSector(new SectorMain0613(6, 13));
        AddSector(new SectorMain0614(6, 14));
        AddSector(new SectorMain0615(6, 15));
        AddSector(new SectorMain0706(7, 6));
        AddSector(new SectorMain0707(7, 7));
        AddSector(new SectorMain0708(7, 8));
        AddSector(new SectorMain0908(9, 8));
        AddSector(new SectorMain0709(07, 9));
        AddSector(new SectorMain0712(07, 12));
        AddSector(new SectorMain0713(07, 13));
        AddSector(new SectorMain0714(07, 14));
        AddSector(new SectorMain0715(07, 15));
        AddSector(new SectorMain1110(11, 10));
        AddSector(new SectorMain1210(12, 10));
        AddSector(new SectorMain1209(12, 9));
        AddSector(new SectorMain1010(10, 10));  // Start- Kladovshik
        AddSector(new SectorMain1009(10, 9));
        AddSector(new SectorMain0904(9, 04));
        AddSector(new SectorMain0906(9, 06));  // Labolatoriy
        AddSector(new SectorMain0907(9, 7));
        AddSector(new SectorMain0910(9, 10));
        AddSector(new SectorMain0911(9, 11));
        AddSector(new SectorMain0912(9, 12));
        AddSector(new SectorMain0913(9, 13));
        AddSector(new SectorMain0914(9, 14));
        AddSector(new SectorMain0915(9, 15));
        AddSector(new SectorMain0810(8, 10));
        AddSector(new SectorMain0804(8, 4));
        AddSector(new SectorMain0806(8, 6));
        AddSector(new SectorMain0807(8, 7));
        AddSector(new SectorMain0808(8, 8));
        AddSector(new SectorMain1004(10, 4));
        AddSector(new SectorMain1005(10, 5));
        AddSector(new SectorMain1006(10, 6));
        AddSector(new SectorMain1007(10, 7));
        AddSector(new SectorMain1008(10, 8));
        AddSector(new SectorMain1011(10, 11));
        AddSector(new SectorMain1012(10, 12));
        AddSector(new SectorMain1106(11, 6));
        AddSector(new SectorMain1107(11, 7));
        AddSector(new SectorMain1108(11, 8));
        AddSector(new SectorMain1109(11, 9));
        AddSector(new SectorMain1111(11, 11));
        AddSector(new SectorMain0909(9, 9));
        AddSector(new SectorMain0710(07, 10));
        AddSector(new SectorMain0811(08, 11)); // Zavod
        AddSector(new SectorMain0812(08, 12));
        AddSector(new SectorMain0813(08, 13));
        AddSector(new SectorMain0814(08, 14));
        AddSector(new SectorMain0815(08, 15));
        AddSector(new SectorMain0711(07, 11));
        AddSector(new SectorMain0809(08, 09));
        AddSector(new SectorMain1206(12, 06));
        AddSector(new SectorMain1207(12, 07));
        AddSector(new SectorMain1208(12, 08));
        AddSector(new SectorMain1211(12, 11));
        AddSector(new SectorMain1212(12, 12)); // Shahta
        AddSector(new SectorMain1306(13, 06));
        AddSector(new SectorMain1307(13, 07));
        AddSector(new SectorMain1308(13, 08));
        AddSector(new SectorMain1309(13, 09));
        AddSector(new SectorMain1310(13, 10));
        AddSector(new SectorMain1311(13, 11));
        AddSector(new SectorMain1312(13, 12));
        AddSector(new SectorMain1313(13, 13));
        AddSector(new SectorMain1314(13, 14));
        AddSector(new SectorMain1315(13, 15));
        AddSector(new SectorMain1406(14, 06));
        AddSector(new SectorMain1407(14, 07));
        AddSector(new SectorMain1408(14, 08));
        AddSector(new SectorMain1409(14, 09));
        AddSector(new SectorMain1410(14, 10));
        AddSector(new SectorMain1411(14, 11));
        AddSector(new SectorMain1412(14, 12));
        AddSector(new SectorMain1413(14, 13));
        AddSector(new SectorMain1414(14, 14));
        AddSector(new SectorMain1415(14, 15));
    }
    public SectorData GetSectorData(string sectorID)
    {
        _sectors.TryGetValue(sectorID, out var sectorData);

        return sectorData;
    }

    private void AddSector(SectorData sectorData)
    {
        _sectors.Add(sectorData.ID, sectorData);
    }


}

using System.Collections.Generic;

public class DataSource : IDataSource
{
    private Dictionary<string, SectorData> _sectors = new Dictionary<string, SectorData>();
    public DataSource()
    {
        // Mine_A

        AddSector(new SectorMine0808(08,08));
        AddSector(new SectorMine0908(09,08));
        AddSector(new SectorMine0909(09,09));
        AddSector(new SectorMine0910(09,10));
        AddSector(new SectorMine0912(09,12));
        AddSector(new SectorMine1007(10,07));
        AddSector(new SectorMine1008(10,08));
        AddSector(new SectorMine1010(10,10));// �����- ����
        AddSector(new SectorMine1011(10,11));
        AddSector(new SectorMine1012(10,12));
        AddSector(new SectorMine1108(11,08));
        AddSector(new SectorMine1109(11,09));
        AddSector(new SectorMine1110(11,10));
        AddSector(new SectorMine1209(12,09));


        // Global_Map_A
        AddSector(new SectorMain0404(4, 4));
        AddSector(new SectorMain0405(4, 5));
        AddSector(new SectorMain0406(4, 6));
        AddSector(new SectorMain0407(4, 7));
        AddSector(new SectorMain0408(4, 8));
        AddSector(new SectorMain0409(4, 9));
        AddSector(new SectorMain0410(4, 10));
        AddSector(new SectorMain0411(4, 11));
        AddSector(new SectorMain0412(4, 12));
        AddSector(new SectorMain0413(4, 13));
        AddSector(new SectorMain0414(4, 14));
        AddSector(new SectorMain0415(4, 15));
        AddSector(new SectorMain0416(4, 16));
        AddSector(new SectorMain0417(4, 17));
        AddSector(new SectorMain0504(5, 4));
        AddSector(new SectorMain0505(5, 5));
        AddSector(new SectorMain0506(5, 6));
        AddSector(new SectorMain0507(5, 7));
        AddSector(new SectorMain0508(5, 8));
        AddSector(new SectorMain0509(5, 9));
        AddSector(new SectorMain0510(5, 10));
        AddSector(new SectorMain0511(5, 11));
        AddSector(new SectorMain0512(5, 12));
        AddSector(new SectorMain0513(5, 13));
        AddSector(new SectorMain0514(5, 14));
        AddSector(new SectorMain0515(5, 15));
        AddSector(new SectorMain0516(5, 16));
        AddSector(new SectorMain0517(5, 17));
        AddSector(new SectorMain0604(6, 4));
        AddSector(new SectorMain0605(6, 5));
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
        AddSector(new SectorMain0616(6, 16));
        AddSector(new SectorMain0617(6, 17));
        AddSector(new SectorMain0704(7, 4));
        AddSector(new SectorMain0705(7, 5));
        AddSector(new SectorMain0706(7, 6));
        AddSector(new SectorMain0707(7, 7));
        AddSector(new SectorMain0708(7, 8));
        AddSector(new SectorMain0908(9, 8));
        AddSector(new SectorMain0709(07, 9));
        AddSector(new SectorMain0712(07, 12));
        AddSector(new SectorMain0713(07, 13));
        AddSector(new SectorMain0714(07, 14));
        AddSector(new SectorMain0715(07, 15));
        AddSector(new SectorMain0716(07, 16));
        AddSector(new SectorMain0717(07, 17));
        AddSector(new SectorMain1110(11, 10));
        AddSector(new SectorMain1210(12, 10));
        AddSector(new SectorMain1209(12, 9));
        AddSector(new SectorMain1010(10, 10));  // Start- Kladovshik
        AddSector(new SectorMain1009(10, 9));
        AddSector(new SectorMain0904(9, 04));
        AddSector(new SectorMain0905(9, 05));
        AddSector(new SectorMain0906(9, 06)); 
        AddSector(new SectorMain0907(9, 7));
        AddSector(new SectorMain0910(9, 10));
        AddSector(new SectorMain0911(9, 11));
        AddSector(new SectorMain0912(9, 12));
        AddSector(new SectorMain0913(9, 13));
        AddSector(new SectorMain0914(9, 14));
        AddSector(new SectorMain0915(9, 15));
        AddSector(new SectorMain0916(9, 16));
        AddSector(new SectorMain0917(9, 17));
        AddSector(new SectorMain0810(8, 10));
        AddSector(new SectorMain0804(8, 4));  // Labolatoriy
        AddSector(new SectorMain0805(8, 5));
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
        AddSector(new SectorMain1013(10, 13));
        AddSector(new SectorMain1104(11, 4));
        AddSector(new SectorMain1105(11, 5));
        AddSector(new SectorMain1106(11, 6));
        AddSector(new SectorMain1107(11, 7));
        AddSector(new SectorMain1108(11, 8));
        AddSector(new SectorMain1109(11, 9));
        AddSector(new SectorMain1111(11, 11));
        AddSector(new SectorMain1112(11, 12));
        AddSector(new SectorMain0909(9, 9));
        AddSector(new SectorMain0710(07, 10));
        AddSector(new SectorMain0811(08, 11)); // Zavod
        AddSector(new SectorMain0812(08, 12));
        AddSector(new SectorMain0813(08, 13));
        AddSector(new SectorMain0814(08, 14));
        AddSector(new SectorMain0815(08, 15));
        AddSector(new SectorMain0816(08, 16));
        AddSector(new SectorMain0817(08, 17));
        AddSector(new SectorMain0711(07, 11));
        AddSector(new SectorMain0809(08, 09));
        AddSector(new SectorMain1204(12, 04));
        AddSector(new SectorMain1205(12, 05));
        AddSector(new SectorMain1206(12, 06));
        AddSector(new SectorMain1207(12, 07));
        AddSector(new SectorMain1208(12, 08));
        AddSector(new SectorMain1211(12, 11));
        AddSector(new SectorMain1212(12, 12));
        AddSector(new SectorMain1304(13, 04));
        AddSector(new SectorMain1305(13, 05));
        AddSector(new SectorMain1306(13, 06));
        AddSector(new SectorMain1307(13, 07));
        AddSector(new SectorMain1308(13, 08));
        AddSector(new SectorMain1309(13, 09));
        AddSector(new SectorMain1310(13, 10));
        AddSector(new SectorMain1311(13, 11));
        AddSector(new SectorMain1312(13, 12));
        AddSector(new SectorMain1313(13, 13));
        //AddSector(new SectorMain1314(13, 14));
        //AddSector(new SectorMain1315(13, 15));
        AddSector(new SectorMain1404(14, 04));
        AddSector(new SectorMain1405(14, 05));
        AddSector(new SectorMain1406(14, 06));
        AddSector(new SectorMain1407(14, 07));
        AddSector(new SectorMain1408(14, 08));
        AddSector(new SectorMain1409(14, 09));
        AddSector(new SectorMain1410(14, 10));
        AddSector(new SectorMain1411(14, 11));
        AddSector(new SectorMain1412(14, 12));
        AddSector(new SectorMain1413(14, 13));  // Shahta
        AddSector(new SectorMain1414(14, 14));  
        AddSector(new SectorMain1415(14, 15));
        AddSector(new SectorMain1416(14, 16));
        AddSector(new SectorMain1417(14, 17));
        AddSector(new SectorMain1504(15, 04));
        AddSector(new SectorMain1505(15, 05));
        AddSector(new SectorMain1506(15, 06));
        AddSector(new SectorMain1507(15, 07));
        AddSector(new SectorMain1508(15, 08));
        AddSector(new SectorMain1509(15, 09));
        AddSector(new SectorMain1510(15, 10));
        AddSector(new SectorMain1511(15, 11));
        AddSector(new SectorMain1512(15, 12));
        AddSector(new SectorMain1513(15, 13));
        AddSector(new SectorMain1514(15, 14));
        AddSector(new SectorMain1515(15, 15));
        AddSector(new SectorMain1516(15, 16));
        AddSector(new SectorMain1517(15, 17));
        AddSector(new SectorMain1604(16, 04));
        AddSector(new SectorMain1605(16, 05));
        AddSector(new SectorMain1606(16, 06));
        AddSector(new SectorMain1607(16, 07));
        AddSector(new SectorMain1608(16, 08));
        AddSector(new SectorMain1609(16, 09));
        AddSector(new SectorMain1610(16, 10));
        AddSector(new SectorMain1611(16, 11));
        AddSector(new SectorMain1612(16, 12));
        AddSector(new SectorMain1613(16, 13));
        AddSector(new SectorMain1614(16, 14));
        AddSector(new SectorMain1615(16, 15));
        AddSector(new SectorMain1616(16, 16));
        AddSector(new SectorMain1617(16, 17));
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

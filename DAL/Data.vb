Imports System.Data.SqlClient
Imports MODEL

Public Class Data



    Public Function getData() As DataTable
        Dim connStr As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")
        Dim conn As SqlConnection = Common.DataHelper.getSQLServerConnectionObject(connStr)
        Dim ds As New DataSet()

        Try
            Dim sql As String = " Select TOP 10 * FROM v_data order by panelTime Desc "
            Dim adp As New SqlDataAdapter(sql, conn)
            adp.SelectCommand.CommandType = CommandType.Text
            adp.Fill(ds)

            Return ds.Tables(0)

        Catch ex As Exception
            '      Common.DataHelper.WriteLogFile("Call Function getDepartment_Search_L1 - ERROR: " + ex.Message, LogFileName);
            Throw ex
        Finally
            conn.Close()
        End Try
    End Function


    Public Function getDataInside(criteria As MODEL.Criteria) As DataTable
        Dim connStr As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")
        Dim insideDoor As String = System.Configuration.ConfigurationSettings.AppSettings("InsideDoor")
        Dim outsideDoor As String = System.Configuration.ConfigurationSettings.AppSettings("OutsideDoor")
        Dim conn As SqlConnection = COMMON.DataHelper.getSQLServerConnectionObject(connStr)
        Dim ds As New DataSet()

        Dim dt1, dt2 As String
        dt1 = panelDT(criteria.dateFrom)
        dt2 = panelDT(criteria.dateTo)


        Try
            Dim sql As String

            'sql = "  SELECT dbo.ViewEvents.priority,dbo.ViewUser.FirstName, dbo.ViewUser.LastName, dbo.ViewEvents.DoorNumberText, dbo.ViewUser.UserInfo4 AS Company, "
            'sql += " dbo.ViewEvents.PanelTime, dbo.ViewUser.UserNumber into #tmp1"
            'sql += " FROM dbo.ViewEvents INNER JOIN"
            'sql += " dbo.ViewUser ON dbo.ViewEvents.UserNumber = dbo.ViewUser.UserNumber and dbo.ViewEvents.priority=1000"


            'sql += " Select distinct(usernumber),max(paneltime) as panelTime,firstname,lastname,company,'#' as panelTimeOutput"
            'sql += " into #tmpIn"
            'sql += " FROM #tmp1  Where doornumbertext = '" + insideDoor + "' AND panelTime > " + dt1 + " and panelTime < " + dt2
            'sql += " group by usernumber,firstname,lastname,company"

            'sql += " Select distinct usernumber,max(paneltime) as panelTime,firstname,lastname,company,'#' as panelTimeOutput"
            'sql += " into #tmpOut"
            'sql += " FROM #tmp1  Where doornumbertext = '" + outsideDoor + "' AND panelTime > " + dt1 + " and panelTime < " + dt2
            'sql += " group by usernumber,firstname,lastname,company"

            'sql += " select * into #tmpInside From (select a.*   from #tmpIn as a,#tmpOut as b "
            'sql += " where a.panelTime > b.panelTime And a.usernumber = b.usernumber"
            'sql += " union"
            'sql += " select * from #tmpIn where usernumber not in(select #tmpOut.usernumber from #tmpOut)) as c"
            'sql += " select usernumber,paneltime,firstname +'  '+ lastname as firstname,company,paneltimeOutput from #tmpInside"

            'sql += " drop table #tmpIn"
            'sql += " drop table #tmpOut"
            'sql += " drop table #tmpInside"
            'sql += " drop table #tmp1"


            sql = "  SELECT dbo.ViewEvents.priority,dbo.ViewUser.FirstName, dbo.ViewUser.LastName, dbo.ViewEvents.DoorNumberText,isnull(vf.NameInIndex,vf3.NameInIndex) AS Company,vf2.NameInIndex as Dept, "
            sql += " dbo.ViewEvents.PanelTime, dbo.ViewUser.UserNumber into #tmp1"
            sql += " FROM dbo.ViewEvents INNER JOIN"
            sql += " dbo.ViewUser ON dbo.ViewEvents.UserNumber = dbo.ViewUser.UserNumber and dbo.ViewEvents.priority=1000 "
            sql += " AND (panelTime > " + dt1 + " and panelTime < " + dt2 + ") "
            sql += " left join ViewDropDownFields as vf on vf.Index_ = '3' and dbo.ViewUser.UserInfoDropDown4 = vf.DropDownID"
            sql += " left join ViewDropDownFields as vf2 on vf2.Index_ = '6' and dbo.ViewUser.UserInfoDropDown7 = vf2.DropDownID "
            sql += " left join ViewDropDownFields as vf3 on vf3.Index_ = '10' and dbo.ViewUser.UserInfoDropDown11 = vf3.DropDownID "


            sql += " Select distinct(usernumber),max(paneltime) as panelTime,firstname,lastname,company,Dept,'#' as panelTimeOutput"
            sql += " into #tmpIn"
            sql += " FROM #tmp1  Where doornumbertext = '" + insideDoor + "' AND panelTime > " + dt1 + " and panelTime < " + dt2
            sql += " group by usernumber,firstname,lastname,company,Dept"

            sql += " Select distinct usernumber,max(paneltime) as panelTime,firstname,lastname,company,Dept,'#' as panelTimeOutput"
            sql += " into #tmpOut"
            sql += " FROM #tmp1  Where doornumbertext = '" + outsideDoor + "' AND panelTime > " + dt1 + " and panelTime < " + dt2
            sql += " group by usernumber,firstname,lastname,company,Dept"

            sql += " select * into #tmpInside From (select a.*   from #tmpIn as a,#tmpOut as b "
            sql += " where a.panelTime > b.panelTime And a.usernumber = b.usernumber"
            sql += " union"
            sql += " select * from #tmpIn where usernumber not in(select #tmpOut.usernumber from #tmpOut)) as c"
            sql += " select usernumber,paneltime,firstname +'  '+ lastname as firstname,company,Dept,paneltimeOutput from #tmpInside"

            sql += " drop table #tmpIn"
            sql += " drop table #tmpOut"
            sql += " drop table #tmpInside"
            sql += " drop table #tmp1"




            Dim adp As New SqlDataAdapter(sql, conn)
            adp.SelectCommand.CommandType = CommandType.Text
            adp.Fill(ds)

            Return ds.Tables(0)

        Catch ex As Exception
            '      Common.DataHelper.WriteLogFile("Call Function getDepartment_Search_L1 - ERROR: " + ex.Message, LogFileName);
            Throw ex
        Finally
            conn.Close()
        End Try
    End Function



    Public Function getDataMissing(criteria As MODEL.Criteria) As DataTable
        Dim connStr As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")
        Dim doorIN As String = System.Configuration.ConfigurationSettings.AppSettings("MissingDoorIn")
        Dim doorOUT As String = System.Configuration.ConfigurationSettings.AppSettings("MissingDoorOut")
        Dim doorCheckPoint As String = System.Configuration.ConfigurationSettings.AppSettings("MissingDoorCheckPoint")



        Dim conn As SqlConnection = COMMON.DataHelper.getSQLServerConnectionObject(connStr)
        Dim ds As New DataSet()

        Dim dt1, dt2 As String
        dt1 = panelDT(criteria.dateFrom)
        dt2 = panelDT(criteria.dateTo)


        Try
            Dim sql As String


            'sql = "  SELECT dbo.ViewUser.FirstName, dbo.ViewUser.LastName, dbo.ViewEvents.DoorNumberText, dbo.ViewUser.UserInfo4 AS Company, "
            'sql += " dbo.ViewEvents.PanelTime,dbo.ViewEvents.priority, dbo.ViewUser.UserNumber into #tmp1"
            'sql += " FROM dbo.ViewEvents INNER JOIN"
            'sql += " dbo.ViewUser ON dbo.ViewEvents.UserNumber = dbo.ViewUser.UserNumber and dbo.ViewEvents.priority=1000 "

            'sql += " Select distinct(usernumber),max(paneltime) as panelTime,firstname,lastname,company,'#' as panelTimeOutput"
            'sql += " into #tmpIn"
            'sql += " FROM  #tmp1  Where doornumbertext = '" + doorIN + "' AND panelTime > " + dt1 + " and panelTime < " + dt2
            'sql += " group by usernumber,firstname,lastname,company"

            'sql += " Select distinct usernumber,max(paneltime) as panelTime,firstname,lastname,company,'#' as panelTimeOutput"
            'sql += " into #tmpOut"
            'sql += " FROM #tmp1 Where doornumbertext = '" + doorOUT + "' AND panelTime > " + dt1 + " and panelTime < " + dt2
            'sql += " group by usernumber,firstname,lastname,company"

            'sql += " select * into #tmpInside From (select a.*   from #tmpIn as a,#tmpOut as b "
            'sql += " where a.panelTime > b.panelTime And a.usernumber = b.usernumber"
            'sql += " union"
            'sql += " select * from #tmpIn where usernumber not in(select #tmpOut.usernumber from #tmpOut)) as c"


            'sql += " select * into #tmpCheckPoint from #tmp1 where doornumbertext in (" + doorCheckPoint + ") and (panelTime > " + dt1 + " and panelTime < " + dt2 + ") "
            'sql += " select usernumber,paneltime,firstname +'  '+ lastname as firstname,company,paneltimeOutput from #tmpInside where #tmpInside.usernumber not in(select #tmpCheckPoint.usernumber from #tmpCheckPoint)"



            'sql += " drop table #tmpIn"
            'sql += " drop table #tmpOut"
            'sql += " drop table #tmpInside"
            'sql += " drop table #tmpCheckPoint"
            'sql += " drop table #tmp1"


            sql = "  SELECT dbo.ViewUser.FirstName, dbo.ViewUser.LastName, dbo.ViewEvents.DoorNumberText,isnull(vf.NameInIndex,vf3.NameInIndex) AS Company,vf2.NameInIndex as Dept, "
            sql += " dbo.ViewEvents.PanelTime,dbo.ViewEvents.priority, dbo.ViewUser.UserNumber into #tmp1"
            sql += " FROM dbo.ViewEvents INNER JOIN"
            sql += " dbo.ViewUser ON dbo.ViewEvents.UserNumber = dbo.ViewUser.UserNumber and dbo.ViewEvents.priority=1000 "
            sql += " AND (panelTime > " + dt1 + " and panelTime < " + dt2 + ") "
            sql += " left join ViewDropDownFields as vf on vf.Index_ = '3' and dbo.ViewUser.UserInfoDropDown4 = vf.DropDownID"
            sql += " left join ViewDropDownFields as vf2 on vf2.Index_ = '6' and dbo.ViewUser.UserInfoDropDown7 = vf2.DropDownID "
            sql += " left join ViewDropDownFields as vf3 on vf3.Index_ = '10' and dbo.ViewUser.UserInfoDropDown11 = vf3.DropDownID "

            sql += " Select distinct(usernumber),max(paneltime) as panelTime,firstname,lastname,company,Dept,'#' as panelTimeOutput"
            sql += " into #tmpIn"
            sql += " FROM  #tmp1  Where doornumbertext = '" + doorIN + "' AND panelTime > " + dt1 + " and panelTime < " + dt2
            sql += " group by usernumber,firstname,lastname,company,Dept"

            sql += " Select distinct usernumber,max(paneltime) as panelTime,firstname,lastname,company,Dept,'#' as panelTimeOutput"
            sql += " into #tmpOut"
            sql += " FROM #tmp1 Where doornumbertext = '" + doorOUT + "' AND panelTime > " + dt1 + " and panelTime < " + dt2
            sql += " group by usernumber,firstname,lastname,company,Dept"

            sql += " select * into #tmpInside From (select a.*   from #tmpIn as a,#tmpOut as b "
            sql += " where a.panelTime > b.panelTime And a.usernumber = b.usernumber"
            sql += " union"
            sql += " select * from #tmpIn where usernumber not in(select #tmpOut.usernumber from #tmpOut)) as c"


            sql += " select * into #tmpCheckPoint from #tmp1 where doornumbertext in (" + doorCheckPoint + ") and (panelTime > " + dt1 + " and panelTime < " + dt2 + ") "
            sql += " select usernumber,paneltime,firstname +'  '+ lastname as firstname,company,Dept,paneltimeOutput from #tmpInside where #tmpInside.usernumber not in(select #tmpCheckPoint.usernumber from #tmpCheckPoint)"



            sql += " drop table #tmpIn"
            sql += " drop table #tmpOut"
            sql += " drop table #tmpInside"
            sql += " drop table #tmpCheckPoint"
            sql += " drop table #tmp1"


            Dim adp As New SqlDataAdapter(sql, conn)
            adp.SelectCommand.CommandType = CommandType.Text
            adp.Fill(ds)

            Return ds.Tables(0)

        Catch ex As Exception
            '      Common.DataHelper.WriteLogFile("Call Function getDepartment_Search_L1 - ERROR: " + ex.Message, LogFileName);
            Throw ex
        Finally
            conn.Close()
        End Try
    End Function

    Public Function getDataCheckPoint(criteria As MODEL.Criteria) As DataTable
        Dim connStr As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")
        Dim CheckPointDoor As String = System.Configuration.ConfigurationSettings.AppSettings("CheckPointDoor")

        Dim conn As SqlConnection = COMMON.DataHelper.getSQLServerConnectionObject(connStr)
        Dim ds As New DataSet()

        Dim dt1, dt2 As String
        dt1 = panelDT(criteria.dateFrom)
        dt2 = panelDT(criteria.dateTo)


        Try
            Dim sql As String


            'sql = "  SELECT dbo.ViewUser.FirstName, dbo.ViewUser.LastName, dbo.ViewUser.UserInfo4 AS Company, "
            'sql += " dbo.ViewEvents.PanelTime,dbo.ViewEvents.DoorNumbertext, dbo.ViewUser.UserNumber into #tmp1"
            'sql += " FROM dbo.ViewEvents INNER JOIN"
            'sql += " dbo.ViewUser ON dbo.ViewEvents.UserNumber = dbo.ViewUser.UserNumber "

            'sql += " Select firstname + '  ' + lastname as firstname,company,paneltime,DoorNumberText,'' as panelTimeOutput  FROM #tmp1 "
            'sql += " Where  DoornumberText in (" + CheckPointDoor + ") and panelTime > " + dt1 + " and panelTime < " + dt2
            'sql += " Order by company,panelTime Desc "

            'sql += " drop table #tmp1"


            sql = "  SELECT dbo.ViewUser.FirstName, dbo.ViewUser.LastName,isnull(vf.NameInIndex,vf3.NameInIndex) AS Company,vf2.NameInIndex as Dept, "
            sql += " dbo.ViewEvents.PanelTime,dbo.ViewEvents.DoorNumbertext, dbo.ViewUser.UserNumber into #tmp1"
            sql += " FROM dbo.ViewEvents INNER JOIN"
            sql += " dbo.ViewUser ON dbo.ViewEvents.UserNumber = dbo.ViewUser.UserNumber "
            sql += " AND (panelTime > " + dt1 + " and panelTime < " + dt2 + ") "
            sql += " left join ViewDropDownFields as vf on vf.Index_ = '3' and dbo.ViewUser.UserInfoDropDown4 = vf.DropDownID"
            sql += " left join ViewDropDownFields as vf2 on vf2.Index_ = '6' and dbo.ViewUser.UserInfoDropDown7 = vf2.DropDownID "
            sql += " left join ViewDropDownFields as vf3 on vf3.Index_ = '10' and dbo.ViewUser.UserInfoDropDown11 = vf3.DropDownID "



            sql += " Select firstname + '  ' + lastname as firstname,company,Dept,paneltime,DoorNumberText,'' as panelTimeOutput  FROM #tmp1 "
            sql += " Where  DoornumberText in (" + CheckPointDoor + ") and panelTime > " + dt1 + " and panelTime < " + dt2
            sql += " Order by company,panelTime Desc "

            sql += " drop table #tmp1"

            Dim adp As New SqlDataAdapter(sql, conn)
            adp.SelectCommand.CommandType = CommandType.Text
            adp.Fill(ds)

            Return ds.Tables(0)

        Catch ex As Exception
            '      Common.DataHelper.WriteLogFile("Call Function getDepartment_Search_L1 - ERROR: " + ex.Message, LogFileName);
            Throw ex
        Finally
            conn.Close()
        End Try
    End Function

    Private Function panelDT(panelTime As String) As String

        '   10/08/2018 14:00
        ' 05/10/2018 0:00:00

        Dim tmpDate(), tmpTime() As String
        tmpDate = panelTime.Split(" ")


        Dim MM, DD, HH, MN, SS, tmp As String

        'MM = Now.Month
        DD = tmpDate(0).Substring(0, 2)
        MM = tmpDate(0).Substring(3, 2)



        If tmpDate(1).Length = 7 Then
            HH = tmpDate(1).Substring(0, 1)
            MN = tmpDate(1).Substring(2, 2)
        Else
            HH = tmpDate(1).Substring(0, 2)
            MN = tmpDate(1).Substring(3, 2)

        End If
     
        SS = "00"

        tmp = (MM * 100000000) + (DD * 1000000) + (Int(HH) * 10000) + (Int(MN) * 100) + SS
        Return tmp

        'SS = panelTime.Substring(panelTime.Length - 2, 2)
        'MN = panelTime.Substring(panelTime.Length - 4, 2)
        'HH = panelTime.Substring(panelTime.Length - 6, 2)
        'DD = panelTime.Substring(panelTime.Length - 8, 2)
        'If panelTime.Length = 9 Then
        '    MM = "0" + panelTime.Substring(0, 1)
        'Else
        '    MM = panelTime.Substring(0, 2)
        'End If


        'Return DD & "/" & MM & " " & HH & ":" & MN & ":" & SS



    End Function

    Public Function panelDTOutput(panelTime As String) As String



        Dim MM, DD, HH, MN, SS, yyyy As String



        yyyy = Date.Now.Year.ToString()
        SS = panelTime.Substring(panelTime.Length - 2, 2)
        MN = panelTime.Substring(panelTime.Length - 4, 2)
        HH = panelTime.Substring(panelTime.Length - 6, 2)
        DD = panelTime.Substring(panelTime.Length - 8, 2)
        If panelTime.Length = 9 Then
            MM = "0" + panelTime.Substring(0, 1)
        Else
            MM = panelTime.Substring(0, 2)
        End If


        Return DD & "/" & MM & "/" & yyyy & " " & HH & ":" & MN & ":" & SS



    End Function


    Public Function getNewData(panelTimeTmp As Integer) As Boolean
        Dim connStr As String = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")

        Dim conn As SqlConnection = COMMON.DataHelper.getSQLServerConnectionObject(connStr)
        Dim ds As New DataSet()

        Try
            Dim sql As String = " Select panelTime FROM v_data Where panelTime > " & panelTimeTmp
            Dim adp As New SqlDataAdapter(sql, conn)
            adp.SelectCommand.CommandType = CommandType.Text
            adp.Fill(ds)


            Dim dt As DataTable
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False

            End If


        Catch ex As Exception
            '      Common.DataHelper.WriteLogFile("Call Function getDepartment_Search_L1 - ERROR: " + ex.Message, LogFileName);
            Throw ex
        Finally
            conn.Close()
        End Try
    End Function

End Class

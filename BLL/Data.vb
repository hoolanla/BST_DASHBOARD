Public Class Data

    Dim _DAL As New DAL.Data

    Public Function getDataInside(criteria As MODEL.Criteria) As DataTable
        Return _DAL.getDataInside(criteria)
    End Function

    Public Function panelDTOutput(panelTime As String) As String
        Return _DAL.panelDTOutput(panelTime)
    End Function

    Public Function getDataMissing(criteria As MODEL.Criteria) As DataTable
        Return _DAL.getDataMissing(criteria)
    End Function

    Public Function getDataCheckPoint(criteria As MODEL.Criteria) As DataTable
        Return _DAL.getDataCheckPoint(criteria)
    End Function
End Class

﻿' R- Instat
' Copyright (C) 2015-2017
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License 
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

Imports instat.Translations
Imports RDotNet
Imports unvell.ReoGrid
Imports unvell.ReoGrid.Events

Public Class dlgName
    Dim bFirstLoad As Boolean = True
    Private bReset As Boolean = True
    Dim bUseSelectedColumn As Boolean = False
    Dim strSelectedColumn As String = ""
    Dim strSelectedDataFrame As String = ""
    Dim strEmpty As String = " "
    Private clsDefaultRFunction As New RFunction
    Private clsNewColNameDataframeFunction As New RFunction
    Private clsNewLabelDataframeFunction As New RFunction
    Private clsDummyFunction As New RFunction
    Private clsDummyRenameWithFunction As New RFunction
    Private WithEvents grdCurrentWorkSheet As Worksheet
    Private bIncludeCopyOfLevels As Boolean
    Private dctRowsNewNameChanged As New Dictionary(Of Integer, String)
    Private dctRowsNewLabelChanged As New Dictionary(Of Integer, String)
    Private dctNameRowsValues As New Dictionary(Of Integer, String)
    Private dctCaseOptions As New Dictionary(Of String, String)
    Private bCurrentCell As Boolean = False

    Private Sub dlgName_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            InitialiseDialog()
            bFirstLoad = False
        End If
        If bReset Then
            SetDefaults()
        End If
        SetRCodeForControls(bReset)
        bReset = False
        If bUseSelectedColumn Then
            SetSelectedColumn()
        End If
        autoTranslate(Me)
    End Sub

    Private Sub InitialiseDialog()
        ucrBase.iHelpTopicID = 33

        ucrSelectVariables.SetParameter(New RParameter("data_name", 0))
        ucrSelectVariables.SetParameterIsString()

        ucrReceiverName.SetParameter(New RParameter("column_name", 1))
        ucrReceiverName.SetParameterIsString()
        ucrReceiverName.Selector = ucrSelectVariables

        ucrInputNewName.SetParameter(New RParameter("new_val", 2))
        'set validation of ucrInputNewName as an RVariable.(input should not have any R reserved words like 'if','while')
        ucrInputNewName.SetValidationTypeAsRVariable()

        ucrChkIncludeVariable.SetText("Include Variable Labels")
        ucrChkIncludeVariable.SetParameter(New RParameter("checked", 0))
        ucrChkIncludeVariable.SetValuesCheckedAndUnchecked(True, False)

        ucrInputVariableLabel.SetParameter(New RParameter("label", 3))

        ucrPnlOptions.SetParameter(New RParameter("type", 4))
        ucrPnlOptions.AddRadioButton(rdoSingle, Chr(34) & "single" & Chr(34))
        ucrPnlOptions.AddRadioButton(rdoMultiple, Chr(34) & "multiple" & Chr(34))
        ucrPnlOptions.AddRadioButton(rdoRenameWith, Chr(34) & "rename_with" & Chr(34))

        ucrPnlCase.SetParameter(New RParameter("checked", 0))
        ucrPnlCase.AddRadioButton(rdoToLower, "lower")
        ucrPnlCase.AddRadioButton(rdoMakeCleanNames, "make_clean_names")

        ucrPnlOptions.AddToLinkedControls({ucrReceiverName, ucrInputNewName, ucrInputVariableLabel}, {rdoSingle}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrPnlOptions.AddToLinkedControls(ucrReceiverColumns, {rdoRenameWith}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True)
        ucrPnlOptions.AddToLinkedControls(ucrPnlCase, {rdoRenameWith}, bNewLinkedHideIfParameterMissing:=True)
        ucrPnlOptions.AddToLinkedControls(ucrChkIncludeVariable, {rdoMultiple}, bNewLinkedHideIfParameterMissing:=True)
        ucrPnlCase.AddToLinkedControls(ucrInputCase, {rdoMakeCleanNames}, bNewLinkedHideIfParameterMissing:=True)
        ucrReceiverName.SetLinkedDisplayControl(lblCurrentName)
        ucrInputNewName.SetLinkedDisplayControl(lblName)
        ucrInputVariableLabel.SetLinkedDisplayControl(lblVariableLabel)
        ucrReceiverColumns.SetLinkedDisplayControl(lblColumns)
        ucrInputCase.SetLinkedDisplayControl(lblCase)
        ucrPnlCase.SetLinkedDisplayControl(grpOptions)
        ucrChkIncludeVariable.SetLinkedDisplayControl(grdRenameColumns)

        ucrReceiverColumns.SetParameter(New RParameter(".cols", 6))
        ucrReceiverColumns.Selector = ucrSelectVariables
        ucrReceiverColumns.SetParameterIsString()

        ucrInputCase.SetParameter(New RParameter("case", 1))
        dctCaseOptions.Add("Snake", Chr(34) & "snake" & Chr(34))
        dctCaseOptions.Add("Small camel", Chr(34) & "small_camel" & Chr(34))
        dctCaseOptions.Add("Big camel", Chr(34) & "big_camel" & Chr(34))
        dctCaseOptions.Add("Screaming snake", Chr(34) & "screaming_snake" & Chr(34))
        dctCaseOptions.Add("Parsed", Chr(34) & "parsed" & Chr(34))
        dctCaseOptions.Add("Mixed", Chr(34) & "mixed" & Chr(34))
        dctCaseOptions.Add("Lower upper", Chr(34) & "lower_upper" & Chr(34))
        dctCaseOptions.Add("Upper lower", Chr(34) & "upper_lower" & Chr(34))
        dctCaseOptions.Add("Swap", Chr(34) & "swap" & Chr(34))
        dctCaseOptions.Add("All caps", Chr(34) & "all_caps" & Chr(34))
        dctCaseOptions.Add("Lower camel", Chr(34) & "lower_camel" & Chr(34))
        dctCaseOptions.Add("Upper camel", Chr(34) & "upper_camel" & Chr(34))
        dctCaseOptions.Add("Internal parsing", Chr(34) & "internal_parsing" & Chr(34))
        dctCaseOptions.Add("None", Chr(34) & "none" & Chr(34))
        dctCaseOptions.Add("Flip", Chr(34) & "flip" & Chr(34))
        dctCaseOptions.Add("Sentence", Chr(34) & "sentence" & Chr(34))
        dctCaseOptions.Add("Random", Chr(34) & "random" & Chr(34))
        dctCaseOptions.Add("Title", Chr(34) & "title" & Chr(34))
        ucrInputCase.SetDropDownStyleAsNonEditable()
        ucrInputCase.SetItems(dctCaseOptions)
    End Sub

    Public Sub SetDefaults()
        clsDefaultRFunction = New RFunction
        clsNewColNameDataframeFunction = New RFunction
        clsNewLabelDataframeFunction = New RFunction
        clsDummyFunction = New RFunction
        clsDummyRenameWithFunction = New RFunction

        ucrSelectVariables.Reset()
        dctRowsNewNameChanged.Clear()
        dctRowsNewLabelChanged.Clear()

        clsDummyFunction.AddParameter("checked", False, iPosition:=0)

        clsDummyRenameWithFunction.AddParameter("checked", "make_clean_names", iPosition:=0)
        clsDummyRenameWithFunction.AddParameter("case", Chr(34) & "snake" & Chr(34), iPosition:=1)

        clsNewColNameDataframeFunction.SetRCommand("data.frame")

        clsNewLabelDataframeFunction.SetRCommand("data.frame")

        clsDefaultRFunction.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$rename_column_in_data")
        clsDefaultRFunction.AddParameter("type", Chr(34) & "single" & Chr(34), iPosition:=4)
        clsDefaultRFunction.AddParameter(".fn", "janitor::make_clean_names", iPosition:=5)

        ucrBase.clsRsyntax.SetBaseRFunction(clsDefaultRFunction)
    End Sub

    Private Sub SetRCodeForControls(bReset As Boolean)
        ucrSelectVariables.SetRCode(clsDefaultRFunction, bReset)
        ucrReceiverName.SetRCode(clsDefaultRFunction, bReset)
        ucrInputNewName.SetRCode(clsDefaultRFunction, bReset)
        ucrInputVariableLabel.SetRCode(clsDefaultRFunction, bReset)
        ucrPnlCase.SetRCode(clsDummyRenameWithFunction, bReset)
        ucrInputCase.SetRCode(clsDummyRenameWithFunction, bReset)
        ucrPnlOptions.SetRCode(clsDefaultRFunction, bReset)
        ucrReceiverColumns.SetRCode(clsDefaultRFunction, bReset)
        ucrChkIncludeVariable.SetRCode(clsDummyFunction, bReset)
    End Sub

    Private Sub TestOKEnabled()
        If rdoSingle.Checked Then
            If Not ucrReceiverName.IsEmpty() AndAlso Not ucrInputNewName.IsEmpty() Then
                ucrBase.OKEnabled(True)
            Else
                ucrBase.OKEnabled(False)
            End If
        ElseIf rdoRenameWith.Checked Then
            ucrBase.OKEnabled(True)
        Else
            ucrBase.OKEnabled(bCurrentCell)
        End If
    End Sub

    Private Sub AddChangedNewNameRows(iRow As Integer, strNewData As String)
        If Not dctRowsNewNameChanged.ContainsKey(iRow) Then
            dctRowsNewNameChanged.Add(iRow, strNewData)
        Else
            dctRowsNewNameChanged(iRow) = strNewData
        End If
    End Sub

    Private Sub AddChangedNewLabelRows(iRow As Integer, strNewData As String)
        If Not dctRowsNewLabelChanged.ContainsKey(iRow) Then
            dctRowsNewLabelChanged.Add(iRow, strNewData)
        Else
            dctRowsNewLabelChanged(iRow) = strNewData
        End If
    End Sub

    Private Sub AddRowNameValue(iRow As Integer, strNewData As String)
        If Not dctNameRowsValues.ContainsKey(iRow) Then
            dctNameRowsValues.Add(iRow, strNewData)
        End If
    End Sub

    Private Function GetValuesAsVector(dctValues As Dictionary(Of Integer, String)) As String
        Dim strValue As String = ""
        Dim i As Integer
        strValue = strValue & "c("
        For Each iRow As Integer In dctValues.Keys
            If i > 0 Then
                strValue = strValue & ","
            End If
            strValue = strValue & Chr(34) & dctValues(iRow) & Chr(34)
            i = i + 1
        Next
        strValue = strValue & ")"
        Return strValue
    End Function

    Private Sub grdCurrentWorkSheet_AfterPaste(sender As Object, e As RangeEventArgs) Handles grdCurrentWorkSheet.AfterPaste
        Dim iStartRowIndex As Integer = grdCurrentWorkSheet.SelectionRange.Row
        Dim iColIndex As Integer = e.Range.Col

        If e.Range.Rows > 1 Then
            For iRow As Integer = iStartRowIndex To e.Range.EndRow
                Dim strData As String = grdCurrentWorkSheet.Item(row:=iRow, col:=iColIndex).ToString()
                RenameColumns(strData, iRow, e.Range.Col)
            Next
        Else
            Dim strNewData As String = grdCurrentWorkSheet.Item(row:=e.Range.Row, col:=iColIndex).ToString()
            RenameColumns(strNewData, iStartRowIndex, iColIndex)
        End If
    End Sub

    Protected Sub Worksheet_AfterCellKeyDown(sender As Object, e As AfterCellKeyDownEventArgs) Handles grdCurrentWorkSheet.AfterCellKeyDown
        If (e.KeyCode = unvell.ReoGrid.Interaction.KeyCode.Delete OrElse e.KeyCode = unvell.ReoGrid.Interaction.KeyCode.Back) Then
            RenameColumns(e.Cell.Data, e.Cell.Row, e.Cell.Column)
        End If
    End Sub

    Private Sub RenameColumns(strNewData As String, iRowIndex As Integer, iColIndex As Integer)
        If ({"", " ", "TRUE", "FALSE", "T", "F"}.Contains(strNewData) OrElse IsNumeric(strNewData)) AndAlso iColIndex = 1 Then
            bCurrentCell = False
            MsgBox("The column name must not be a numeric or contains space or be a boolean e.g TRUE, FALSE, T, F.")
        Else
            bCurrentCell = True
            GetVariables(strNewData, iRowIndex + 1, iColIndex)
        End If
        TestOKEnabled()
    End Sub

    Protected Sub Worksheet_BeforeCellKeyDown(sender As Object, e As BeforeCellKeyDownEventArgs) Handles grdCurrentWorkSheet.BeforeCellKeyDown
        If (e.KeyCode = unvell.ReoGrid.Interaction.KeyCode.Delete OrElse e.KeyCode = unvell.ReoGrid.Interaction.KeyCode.Back) AndAlso e.Cell.Column = 1 Then
            MsgBox("The column name must not be an empty string.", MsgBoxStyle.Information)
            e.IsCancelled = True
        End If
    End Sub

    Private Sub grdCurrSheet_AfterCellEdit(sender As Object, e As CellAfterEditEventArgs) Handles grdCurrentWorkSheet.AfterCellEdit
        RenameColumns(e.NewData, e.Cell.Row, e.Cell.Column)
    End Sub

    Private Sub GetVariables(strNewData As String, iRowIndex As Integer, iColIndex As Integer)
        If rdoMultiple.Checked Then
            If iColIndex = 1 Then
                If strNewData <> "" Then
                    AddChangedNewNameRows(iRowIndex, strNewData)

                    clsNewColNameDataframeFunction.AddParameter("cols", GetValuesAsVector(dctRowsNewNameChanged), iPosition:=0)
                    clsNewColNameDataframeFunction.AddParameter("index", "c(" & String.Join(",", dctRowsNewNameChanged.Keys.ToArray) & ")", iPosition:=1)
                    clsDefaultRFunction.AddParameter("new_column_names_df", clsRFunctionParameter:=clsNewColNameDataframeFunction, iPosition:=8)
                Else
                    clsNewColNameDataframeFunction.RemoveParameterByName("cols")
                    clsNewColNameDataframeFunction.RemoveParameterByName("index")
                    clsDefaultRFunction.RemoveParameterByName("new_column_names_df")
                End If
            End If

            If ucrChkIncludeVariable.Checked Then
                If iColIndex = 2 Then
                    If strNewData <> "" Then
                        AddChangedNewLabelRows(iRowIndex, strNewData)
                    Else
                        AddChangedNewLabelRows(iRowIndex, strEmpty)
                    End If

                    clsNewLabelDataframeFunction.AddParameter("cols", GetValuesAsVector(dctRowsNewLabelChanged), iPosition:=0)
                    clsNewLabelDataframeFunction.AddParameter("index", "c(" & String.Join(",", dctRowsNewLabelChanged.Keys.ToArray) & ")", iPosition:=1)
                    clsDefaultRFunction.AddParameter("new_labels_df", clsRFunctionParameter:=clsNewLabelDataframeFunction, iPosition:=9)
                End If
                Else
                clsDefaultRFunction.RemoveParameterByName("new_labels_df")
            End If
        End If
    End Sub

    Private Sub RemoveParameters()
        If rdoMultiple.Checked OrElse rdoSingle.Checked Then
            clsDefaultRFunction.RemoveParameterByPosition(5)
        ElseIf rdoRenameWith.Checked Then
            If rdoToLower.Checked Then
                clsDefaultRFunction.AddParameter(".fn", "tolower", iPosition:=5)
                clsDefaultRFunction.RemoveParameterByPosition(7)
                clsDummyRenameWithFunction.AddParameter("checked", "lower", iPosition:=0)
            Else
                clsDefaultRFunction.AddParameter(".fn", "janitor::make_clean_names", iPosition:=5)
                clsDefaultRFunction.AddParameter("case", dctCaseOptions(ucrInputCase.GetText()), iPosition:=7)
                clsDummyRenameWithFunction.AddParameter("checked", "make_clean_names", iPosition:=0)
            End If
        End If
        If rdoSingle.Checked OrElse rdoRenameWith.Checked Then
            clsDefaultRFunction.RemoveParameterByPosition(8)
            clsDefaultRFunction.RemoveParameterByPosition(9)
        End If
    End Sub

    Private Sub UpdateGrid()
        Dim vecColumns As GenericVector = Nothing
        Dim chrCurrColumns As CharacterVector
        Dim clsGetItems As New RFunction
        Dim clsGetColumnLabels As New RFunction
        Dim strCurrColumnLables() As String
        Dim expItems As SymbolicExpression

        grdRenameColumns.Worksheets.Clear()
        dctRowsNewNameChanged.Clear()
        dctNameRowsValues.Clear()
        dctRowsNewLabelChanged.Clear()

        grdCurrentWorkSheet = grdRenameColumns.CreateWorksheet(ucrSelectVariables.strCurrentDataFrame)
        grdCurrentWorkSheet.ColumnCount = 3

        grdCurrentWorkSheet.ColumnHeaders(0).Text = "Name"
        grdCurrentWorkSheet.ColumnHeaders(1).Text = "New Name"
        grdCurrentWorkSheet.ColumnHeaders(2).Text = "Label"
        grdCurrentWorkSheet.SetColumnsWidth(2, 1, 150)

        If rdoMultiple.Checked Then
            If ucrSelectVariables IsNot Nothing Then
                clsGetItems.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$get_column_names")
                clsGetItems.AddParameter("data_name", Chr(34) & ucrSelectVariables.strCurrentDataFrame & Chr(34), iPosition:=0)
                clsGetItems.AddParameter("as_list", "TRUE")
                expItems = frmMain.clsRLink.RunInternalScriptGetValue(clsGetItems.ToScript(), bSilent:=True)
                If expItems IsNot Nothing AndAlso Not expItems.Type = Internals.SymbolicExpressionType.Null Then
                    vecColumns = expItems.AsList
                    For i As Integer = 0 To vecColumns.Count - 1
                        chrCurrColumns = vecColumns(i).AsCharacter
                        Dim strText As String = vecColumns.Names(i)

                        If chrCurrColumns IsNot Nothing Then
                            grdCurrentWorkSheet.RowCount = chrCurrColumns.Count
                            For j As Integer = 0 To chrCurrColumns.Count - 1
                                grdCurrentWorkSheet.Item(row:=j, col:=0) = chrCurrColumns(j)
                                grdCurrentWorkSheet.GetCell(row:=j, col:=0).IsReadOnly = True
                                grdCurrentWorkSheet.Item(row:=j, col:=1) = chrCurrColumns(j)
                            Next
                            clsGetColumnLabels.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$get_column_labels")
                            clsGetColumnLabels.AddParameter("data_name", Chr(34) & vecColumns.Names(i) & Chr(34))
                            clsGetColumnLabels.AddParameter("columns", frmMain.clsRLink.GetListAsRString(chrCurrColumns.ToList))
                            expItems = frmMain.clsRLink.RunInternalScriptGetValue(clsGetColumnLabels.ToScript())
                            If expItems IsNot Nothing AndAlso Not expItems.Type = Internals.SymbolicExpressionType.Null Then
                                strCurrColumnLables = expItems.AsCharacter.ToArray
                            Else
                                strCurrColumnLables = New String(chrCurrColumns.Count - 1) {}
                            End If
                            For j = 0 To chrCurrColumns.Count - 1
                                grdCurrentWorkSheet.Item(row:=j, col:=2) = strCurrColumnLables(j)
                            Next
                        End If
                    Next
                End If

                For iRow As Integer = 0 To grdCurrentWorkSheet.RowCount - 1
                    AddRowNameValue(iRow, grdCurrentWorkSheet.Item(iRow, 0))
                Next
            End If
        End If

        grdCurrentWorkSheet.SetRangeDataFormat(New RangePosition(0, 0, grdCurrentWorkSheet.Rows, grdCurrentWorkSheet.Columns), DataFormat.CellDataFormatFlag.Text)
        grdCurrentWorkSheet.SelectionForwardDirection = unvell.ReoGrid.SelectionForwardDirection.Down
        grdCurrentWorkSheet.SetSettings(unvell.ReoGrid.WorksheetSettings.Edit_DragSelectionToMoveCells, False)
        grdCurrentWorkSheet.SetSettings(unvell.ReoGrid.WorksheetSettings.Edit_DragSelectionToFillSerial, False)
        grdCurrentWorkSheet.SetSettings(unvell.ReoGrid.WorksheetSettings.View_AllowCellTextOverflow, False)

        grdRenameColumns.AddWorksheet(grdCurrentWorkSheet)
        grdRenameColumns.SheetTabNewButtonVisible = False
        grdRenameColumns.SheetTabWidth = 450

        MakeLabelColumnVisible()
    End Sub

    Public Sub SetCurrentColumn(strColumn As String, strDataFrame As String)
        strSelectedColumn = strColumn
        strSelectedDataFrame = strDataFrame
        bUseSelectedColumn = True
    End Sub

    Private Sub SetSelectedColumn()
        ucrSelectVariables.SetDataframe(strSelectedDataFrame)
        ucrReceiverName.Add(strSelectedColumn, strSelectedDataFrame)
        bUseSelectedColumn = False
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOKEnabled()
    End Sub

    Private Sub ucrReceiverName_ControlValueChanged() Handles ucrReceiverName.ControlValueChanged
        'if the receiver is not empty
        If Not ucrReceiverName.IsEmpty Then
            'if the user has not typed anything then change the ucrInputNewName contents
            ucrInputNewName.SetName(ucrReceiverName.GetVariableNames(bWithQuotes:=False))
            'get the label of the column selected(from ucrReceiverName) and set it as ucrInputVariableLabel value
            ucrInputVariableLabel.SetName(GetColLabel())

        Else
            'if the receiver is empty. These 2 controls should be empty
            ucrInputNewName.SetName("")
            ucrInputVariableLabel.SetName("")
        End If

    End Sub

    'Gets the label of the column selected(from ucrReceiverName) 
    Private Function GetColLabel()
        Dim strColLabel As String = ""
        Dim clsColmnLabelsRFunction = New RFunction
        Dim expItems As SymbolicExpression

        clsColmnLabelsRFunction.SetRCommand(frmMain.clsRLink.strInstatDataObject & "$get_column_labels")
        clsColmnLabelsRFunction.AddParameter("data_name", Chr(34) & ucrSelectVariables.strCurrentDataFrame & Chr(34), iPosition:=0)
        clsColmnLabelsRFunction.AddParameter("columns", ucrReceiverName.GetVariableNames(bWithQuotes:=True), iPosition:=1)

        expItems = frmMain.clsRLink.RunInternalScriptGetValue(clsColmnLabelsRFunction.ToScript(), bSilent:=True)

        If expItems IsNot Nothing AndAlso Not (expItems.Type = Internals.SymbolicExpressionType.Null) Then
            Dim strArr As String() = expItems.AsCharacter.ToArray
            If strArr IsNot Nothing Then
                'the number of labels for a column expected is 1
                If strArr.Length = 1 Then
                    strColLabel = strArr(0)
                ElseIf strArr.Length > 1 Then
                    MessageBox.Show(Me, "Developer error: retrieved column label should be one.", "Developer Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    strColLabel = strArr(strArr.Length - 1)
                End If
            End If
        End If
        Return strColLabel
    End Function

    Private Sub ucrPnlOptions_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrPnlOptions.ControlValueChanged, ucrPnlCase.ControlValueChanged, ucrInputCase.ControlValueChanged
        If rdoSingle.Checked Then
            ucrReceiverName.SetMeAsReceiver()
        ElseIf rdoRenameWith.Checked Then
            ucrReceiverColumns.SetMeAsReceiver()
        End If
        ucrSelectVariables.lstAvailableVariable.Visible = If(rdoSingle.Checked OrElse rdoRenameWith.Checked, True, False)
        ucrSelectVariables.btnAdd.Visible = If(rdoSingle.Checked OrElse rdoRenameWith.Checked, True, False)
        ucrSelectVariables.btnDataOptions.Visible = If(rdoSingle.Checked OrElse rdoRenameWith.Checked, True, False)

        UpdateGrid()
        RemoveParameters()
    End Sub

    Private Sub MakeLabelColumnVisible()
        If ucrChkIncludeVariable.Checked Then
            grdCurrentWorkSheet.ShowColumns(2, 1)
        Else
            grdCurrentWorkSheet.HideColumns(2, 1)
        End If
    End Sub

    Private Sub ucrChkIncludeVariable_ControlValueChanged(ucrChangedControl As ucrCore) Handles ucrChkIncludeVariable.ControlValueChanged
        MakeLabelColumnVisible()
    End Sub

    Private Sub cmdAddkeyboard_Click(sender As Object, e As EventArgs)
        sdgConstructRegexExpression.ShowDialog()
    End Sub

    Private Sub ucrSelectVariables_DataFrameChanged() Handles ucrSelectVariables.DataFrameChanged
        UpdateGrid()
    End Sub

    Private Sub ucrBase_ClickOk(sender As Object, e As EventArgs) Handles ucrBase.ClickOk
        If Not ucrReceiverColumns.IsEmpty Then
            ucrReceiverColumns.Clear()
        End If
    End Sub

    Private Sub ucrCoreControls_ControlContentsChanged() Handles ucrInputNewName.ControlContentsChanged, ucrReceiverName.ControlContentsChanged, ucrReceiverColumns.ControlContentsChanged, ucrSelectVariables.ControlContentsChanged, ucrPnlOptions.ControlContentsChanged
        TestOKEnabled()
    End Sub
End Class

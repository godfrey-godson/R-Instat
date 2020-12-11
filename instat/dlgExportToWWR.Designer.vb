﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgExportToWWR
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ucrBase = New instat.ucrButtons()
        Me.ucrSelectorExportToWWR = New instat.ucrSelectorByDataFrameAddRemove()
        Me.ucrReceiverYear = New instat.ucrReceiverSingle()
        Me.ucrReceiverMeanRelativeHumidity = New instat.ucrReceiverSingle()
        Me.ucrReceiverPrecipitation = New instat.ucrReceiverSingle()
        Me.ucrReceiverMeanSeaLevelPressure = New instat.ucrReceiverSingle()
        Me.ucrReceiverMeanMonthlyAirTemperature = New instat.ucrReceiverSingle()
        Me.ucrReceiverMeanDailyMaxAirTemperature = New instat.ucrReceiverSingle()
        Me.ucrReceiverMeanDailyMinAirTemperature = New instat.ucrReceiverSingle()
        Me.ucrReceiverMonth = New instat.ucrReceiverSingle()
        Me.ucrReceiverMeanStationPressure = New instat.ucrReceiverSingle()
        Me.lblStationIdentifier = New System.Windows.Forms.Label()
        Me.lblMeanDailyMinAirTemperature = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.lblMeanStationPressure = New System.Windows.Forms.Label()
        Me.lblMeanSeaLevelPressure = New System.Windows.Forms.Label()
        Me.lblMeanMonthlyAirTemperature = New System.Windows.Forms.Label()
        Me.lblPrecipitation = New System.Windows.Forms.Label()
        Me.lblMeanDailyMaxAirTemperature = New System.Windows.Forms.Label()
        Me.lblMeanRelativeHumidity = New System.Windows.Forms.Label()
        Me.btnStationMetadata = New System.Windows.Forms.Button()
        Me.ucrInputLinkby = New instat.ucrInputComboBox()
        Me.cmdBrowse = New System.Windows.Forms.Button()
        Me.ucrInputFilePath = New instat.ucrInputTextBox()
        Me.lblSaveFile = New System.Windows.Forms.Label()
        Me.ucrReceiverStationIdentifier = New instat.ucrReceiverSingle()
        Me.lblType = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ucrBase
        '
        Me.ucrBase.Location = New System.Drawing.Point(11, 397)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(410, 52)
        Me.ucrBase.TabIndex = 27
        '
        'ucrSelectorExportToWWR
        '
        Me.ucrSelectorExportToWWR.bDropUnusedFilterLevels = False
        Me.ucrSelectorExportToWWR.bShowHiddenColumns = False
        Me.ucrSelectorExportToWWR.bUseCurrentFilter = True
        Me.ucrSelectorExportToWWR.Location = New System.Drawing.Point(9, 9)
        Me.ucrSelectorExportToWWR.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrSelectorExportToWWR.Name = "ucrSelectorExportToWWR"
        Me.ucrSelectorExportToWWR.Size = New System.Drawing.Size(210, 180)
        Me.ucrSelectorExportToWWR.TabIndex = 0
        '
        'ucrReceiverYear
        '
        Me.ucrReceiverYear.frmParent = Me
        Me.ucrReceiverYear.Location = New System.Drawing.Point(258, 134)
        Me.ucrReceiverYear.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverYear.Name = "ucrReceiverYear"
        Me.ucrReceiverYear.Selector = Nothing
        Me.ucrReceiverYear.Size = New System.Drawing.Size(135, 20)
        Me.ucrReceiverYear.strNcFilePath = ""
        Me.ucrReceiverYear.TabIndex = 7
        Me.ucrReceiverYear.ucrSelector = Nothing
        '
        'ucrReceiverMeanRelativeHumidity
        '
        Me.ucrReceiverMeanRelativeHumidity.frmParent = Me
        Me.ucrReceiverMeanRelativeHumidity.Location = New System.Drawing.Point(19, 303)
        Me.ucrReceiverMeanRelativeHumidity.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverMeanRelativeHumidity.Name = "ucrReceiverMeanRelativeHumidity"
        Me.ucrReceiverMeanRelativeHumidity.Selector = Nothing
        Me.ucrReceiverMeanRelativeHumidity.Size = New System.Drawing.Size(158, 20)
        Me.ucrReceiverMeanRelativeHumidity.strNcFilePath = ""
        Me.ucrReceiverMeanRelativeHumidity.TabIndex = 23
        Me.ucrReceiverMeanRelativeHumidity.ucrSelector = Nothing
        '
        'ucrReceiverPrecipitation
        '
        Me.ucrReceiverPrecipitation.frmParent = Me
        Me.ucrReceiverPrecipitation.Location = New System.Drawing.Point(258, 334)
        Me.ucrReceiverPrecipitation.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverPrecipitation.Name = "ucrReceiverPrecipitation"
        Me.ucrReceiverPrecipitation.Selector = Nothing
        Me.ucrReceiverPrecipitation.Size = New System.Drawing.Size(135, 20)
        Me.ucrReceiverPrecipitation.strNcFilePath = ""
        Me.ucrReceiverPrecipitation.TabIndex = 17
        Me.ucrReceiverPrecipitation.ucrSelector = Nothing
        '
        'ucrReceiverMeanSeaLevelPressure
        '
        Me.ucrReceiverMeanSeaLevelPressure.frmParent = Me
        Me.ucrReceiverMeanSeaLevelPressure.Location = New System.Drawing.Point(258, 254)
        Me.ucrReceiverMeanSeaLevelPressure.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverMeanSeaLevelPressure.Name = "ucrReceiverMeanSeaLevelPressure"
        Me.ucrReceiverMeanSeaLevelPressure.Selector = Nothing
        Me.ucrReceiverMeanSeaLevelPressure.Size = New System.Drawing.Size(135, 20)
        Me.ucrReceiverMeanSeaLevelPressure.strNcFilePath = ""
        Me.ucrReceiverMeanSeaLevelPressure.TabIndex = 13
        Me.ucrReceiverMeanSeaLevelPressure.ucrSelector = Nothing
        '
        'ucrReceiverMeanMonthlyAirTemperature
        '
        Me.ucrReceiverMeanMonthlyAirTemperature.frmParent = Me
        Me.ucrReceiverMeanMonthlyAirTemperature.Location = New System.Drawing.Point(258, 294)
        Me.ucrReceiverMeanMonthlyAirTemperature.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverMeanMonthlyAirTemperature.Name = "ucrReceiverMeanMonthlyAirTemperature"
        Me.ucrReceiverMeanMonthlyAirTemperature.Selector = Nothing
        Me.ucrReceiverMeanMonthlyAirTemperature.Size = New System.Drawing.Size(138, 20)
        Me.ucrReceiverMeanMonthlyAirTemperature.strNcFilePath = ""
        Me.ucrReceiverMeanMonthlyAirTemperature.TabIndex = 15
        Me.ucrReceiverMeanMonthlyAirTemperature.ucrSelector = Nothing
        '
        'ucrReceiverMeanDailyMaxAirTemperature
        '
        Me.ucrReceiverMeanDailyMaxAirTemperature.frmParent = Me
        Me.ucrReceiverMeanDailyMaxAirTemperature.Location = New System.Drawing.Point(19, 219)
        Me.ucrReceiverMeanDailyMaxAirTemperature.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverMeanDailyMaxAirTemperature.Name = "ucrReceiverMeanDailyMaxAirTemperature"
        Me.ucrReceiverMeanDailyMaxAirTemperature.Selector = Nothing
        Me.ucrReceiverMeanDailyMaxAirTemperature.Size = New System.Drawing.Size(158, 20)
        Me.ucrReceiverMeanDailyMaxAirTemperature.strNcFilePath = ""
        Me.ucrReceiverMeanDailyMaxAirTemperature.TabIndex = 19
        Me.ucrReceiverMeanDailyMaxAirTemperature.ucrSelector = Nothing
        '
        'ucrReceiverMeanDailyMinAirTemperature
        '
        Me.ucrReceiverMeanDailyMinAirTemperature.frmParent = Me
        Me.ucrReceiverMeanDailyMinAirTemperature.Location = New System.Drawing.Point(19, 262)
        Me.ucrReceiverMeanDailyMinAirTemperature.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverMeanDailyMinAirTemperature.Name = "ucrReceiverMeanDailyMinAirTemperature"
        Me.ucrReceiverMeanDailyMinAirTemperature.Selector = Nothing
        Me.ucrReceiverMeanDailyMinAirTemperature.Size = New System.Drawing.Size(158, 20)
        Me.ucrReceiverMeanDailyMinAirTemperature.strNcFilePath = ""
        Me.ucrReceiverMeanDailyMinAirTemperature.TabIndex = 21
        Me.ucrReceiverMeanDailyMinAirTemperature.ucrSelector = Nothing
        '
        'ucrReceiverMonth
        '
        Me.ucrReceiverMonth.frmParent = Me
        Me.ucrReceiverMonth.Location = New System.Drawing.Point(258, 174)
        Me.ucrReceiverMonth.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverMonth.Name = "ucrReceiverMonth"
        Me.ucrReceiverMonth.Selector = Nothing
        Me.ucrReceiverMonth.Size = New System.Drawing.Size(135, 20)
        Me.ucrReceiverMonth.strNcFilePath = ""
        Me.ucrReceiverMonth.TabIndex = 9
        Me.ucrReceiverMonth.ucrSelector = Nothing
        '
        'ucrReceiverMeanStationPressure
        '
        Me.ucrReceiverMeanStationPressure.frmParent = Me
        Me.ucrReceiverMeanStationPressure.Location = New System.Drawing.Point(258, 214)
        Me.ucrReceiverMeanStationPressure.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverMeanStationPressure.Name = "ucrReceiverMeanStationPressure"
        Me.ucrReceiverMeanStationPressure.Selector = Nothing
        Me.ucrReceiverMeanStationPressure.Size = New System.Drawing.Size(135, 20)
        Me.ucrReceiverMeanStationPressure.strNcFilePath = ""
        Me.ucrReceiverMeanStationPressure.TabIndex = 11
        Me.ucrReceiverMeanStationPressure.ucrSelector = Nothing
        '
        'lblStationIdentifier
        '
        Me.lblStationIdentifier.AutoSize = True
        Me.lblStationIdentifier.Location = New System.Drawing.Point(254, 33)
        Me.lblStationIdentifier.Name = "lblStationIdentifier"
        Me.lblStationIdentifier.Size = New System.Drawing.Size(86, 13)
        Me.lblStationIdentifier.TabIndex = 1
        Me.lblStationIdentifier.Text = "Station Identifier:"
        '
        'lblMeanDailyMinAirTemperature
        '
        Me.lblMeanDailyMinAirTemperature.AutoSize = True
        Me.lblMeanDailyMinAirTemperature.Location = New System.Drawing.Point(16, 246)
        Me.lblMeanDailyMinAirTemperature.Name = "lblMeanDailyMinAirTemperature"
        Me.lblMeanDailyMinAirTemperature.Size = New System.Drawing.Size(161, 13)
        Me.lblMeanDailyMinAirTemperature.TabIndex = 20
        Me.lblMeanDailyMinAirTemperature.Text = "Mean Daily Min Air Temperature:"
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Location = New System.Drawing.Point(255, 118)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(32, 13)
        Me.lblYear.TabIndex = 6
        Me.lblYear.Text = "Year:"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(255, 158)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(40, 13)
        Me.lblMonth.TabIndex = 8
        Me.lblMonth.Text = "Month:"
        '
        'lblMeanStationPressure
        '
        Me.lblMeanStationPressure.AutoSize = True
        Me.lblMeanStationPressure.Location = New System.Drawing.Point(255, 198)
        Me.lblMeanStationPressure.Name = "lblMeanStationPressure"
        Me.lblMeanStationPressure.Size = New System.Drawing.Size(117, 13)
        Me.lblMeanStationPressure.TabIndex = 10
        Me.lblMeanStationPressure.Text = "Mean Station Pressure:"
        '
        'lblMeanSeaLevelPressure
        '
        Me.lblMeanSeaLevelPressure.AutoSize = True
        Me.lblMeanSeaLevelPressure.Location = New System.Drawing.Point(255, 238)
        Me.lblMeanSeaLevelPressure.Name = "lblMeanSeaLevelPressure"
        Me.lblMeanSeaLevelPressure.Size = New System.Drawing.Size(132, 13)
        Me.lblMeanSeaLevelPressure.TabIndex = 12
        Me.lblMeanSeaLevelPressure.Text = "Mean Sea Level Pressure:"
        '
        'lblMeanMonthlyAirTemperature
        '
        Me.lblMeanMonthlyAirTemperature.AutoSize = True
        Me.lblMeanMonthlyAirTemperature.Location = New System.Drawing.Point(254, 278)
        Me.lblMeanMonthlyAirTemperature.Name = "lblMeanMonthlyAirTemperature"
        Me.lblMeanMonthlyAirTemperature.Size = New System.Drawing.Size(141, 13)
        Me.lblMeanMonthlyAirTemperature.TabIndex = 14
        Me.lblMeanMonthlyAirTemperature.Text = "Mean Daily Air Temperature:"
        '
        'lblPrecipitation
        '
        Me.lblPrecipitation.AutoSize = True
        Me.lblPrecipitation.Location = New System.Drawing.Point(250, 318)
        Me.lblPrecipitation.Name = "lblPrecipitation"
        Me.lblPrecipitation.Size = New System.Drawing.Size(98, 13)
        Me.lblPrecipitation.TabIndex = 16
        Me.lblPrecipitation.Text = " Total Precipitation:"
        '
        'lblMeanDailyMaxAirTemperature
        '
        Me.lblMeanDailyMaxAirTemperature.AutoSize = True
        Me.lblMeanDailyMaxAirTemperature.Location = New System.Drawing.Point(16, 204)
        Me.lblMeanDailyMaxAirTemperature.Name = "lblMeanDailyMaxAirTemperature"
        Me.lblMeanDailyMaxAirTemperature.Size = New System.Drawing.Size(164, 13)
        Me.lblMeanDailyMaxAirTemperature.TabIndex = 18
        Me.lblMeanDailyMaxAirTemperature.Text = "Mean Daily Max Air Temperature:"
        '
        'lblMeanRelativeHumidity
        '
        Me.lblMeanRelativeHumidity.AutoSize = True
        Me.lblMeanRelativeHumidity.Location = New System.Drawing.Point(18, 288)
        Me.lblMeanRelativeHumidity.Name = "lblMeanRelativeHumidity"
        Me.lblMeanRelativeHumidity.Size = New System.Drawing.Size(148, 13)
        Me.lblMeanRelativeHumidity.TabIndex = 22
        Me.lblMeanRelativeHumidity.Text = "Mean Daily Relative Humidity:"
        '
        'btnStationMetadata
        '
        Me.btnStationMetadata.Location = New System.Drawing.Point(258, 82)
        Me.btnStationMetadata.Name = "btnStationMetadata"
        Me.btnStationMetadata.Size = New System.Drawing.Size(135, 25)
        Me.btnStationMetadata.TabIndex = 5
        Me.btnStationMetadata.Text = "Station Metadata"
        Me.btnStationMetadata.UseVisualStyleBackColor = True
        '
        'ucrInputLinkby
        '
        Me.ucrInputLinkby.AddQuotesIfUnrecognised = True
        Me.ucrInputLinkby.GetSetSelectedIndex = -1
        Me.ucrInputLinkby.IsReadOnly = False
        Me.ucrInputLinkby.Location = New System.Drawing.Point(398, 49)
        Me.ucrInputLinkby.Name = "ucrInputLinkby"
        Me.ucrInputLinkby.Size = New System.Drawing.Size(96, 21)
        Me.ucrInputLinkby.TabIndex = 4
        '
        'cmdBrowse
        '
        Me.cmdBrowse.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdBrowse.Location = New System.Drawing.Point(311, 363)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(97, 23)
        Me.cmdBrowse.TabIndex = 26
        Me.cmdBrowse.Text = "Browse"
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'ucrInputFilePath
        '
        Me.ucrInputFilePath.AddQuotesIfUnrecognised = True
        Me.ucrInputFilePath.IsMultiline = False
        Me.ucrInputFilePath.IsReadOnly = False
        Me.ucrInputFilePath.Location = New System.Drawing.Point(90, 364)
        Me.ucrInputFilePath.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrInputFilePath.Name = "ucrInputFilePath"
        Me.ucrInputFilePath.Size = New System.Drawing.Size(220, 21)
        Me.ucrInputFilePath.TabIndex = 25
        '
        'lblSaveFile
        '
        Me.lblSaveFile.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSaveFile.Location = New System.Drawing.Point(13, 368)
        Me.lblSaveFile.Name = "lblSaveFile"
        Me.lblSaveFile.Size = New System.Drawing.Size(75, 17)
        Me.lblSaveFile.TabIndex = 24
        Me.lblSaveFile.Text = "Save file(s) to:"
        '
        'ucrReceiverStationIdentifier
        '
        Me.ucrReceiverStationIdentifier.frmParent = Me
        Me.ucrReceiverStationIdentifier.Location = New System.Drawing.Point(258, 49)
        Me.ucrReceiverStationIdentifier.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverStationIdentifier.Name = "ucrReceiverStationIdentifier"
        Me.ucrReceiverStationIdentifier.Selector = Nothing
        Me.ucrReceiverStationIdentifier.Size = New System.Drawing.Size(138, 20)
        Me.ucrReceiverStationIdentifier.strNcFilePath = ""
        Me.ucrReceiverStationIdentifier.TabIndex = 2
        Me.ucrReceiverStationIdentifier.ucrSelector = Nothing
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(396, 32)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(34, 13)
        Me.lblType.TabIndex = 3
        Me.lblType.Text = "Type:"
        '
        'dlgExportToWWR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 453)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.ucrReceiverStationIdentifier)
        Me.Controls.Add(Me.lblSaveFile)
        Me.Controls.Add(Me.cmdBrowse)
        Me.Controls.Add(Me.ucrInputFilePath)
        Me.Controls.Add(Me.ucrInputLinkby)
        Me.Controls.Add(Me.btnStationMetadata)
        Me.Controls.Add(Me.lblMeanRelativeHumidity)
        Me.Controls.Add(Me.lblMeanDailyMaxAirTemperature)
        Me.Controls.Add(Me.lblPrecipitation)
        Me.Controls.Add(Me.lblMeanMonthlyAirTemperature)
        Me.Controls.Add(Me.lblMeanSeaLevelPressure)
        Me.Controls.Add(Me.lblMeanStationPressure)
        Me.Controls.Add(Me.lblMonth)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.lblMeanDailyMinAirTemperature)
        Me.Controls.Add(Me.lblStationIdentifier)
        Me.Controls.Add(Me.ucrReceiverMonth)
        Me.Controls.Add(Me.ucrReceiverMeanStationPressure)
        Me.Controls.Add(Me.ucrReceiverMeanDailyMaxAirTemperature)
        Me.Controls.Add(Me.ucrReceiverMeanDailyMinAirTemperature)
        Me.Controls.Add(Me.ucrReceiverMeanSeaLevelPressure)
        Me.Controls.Add(Me.ucrReceiverMeanMonthlyAirTemperature)
        Me.Controls.Add(Me.ucrReceiverPrecipitation)
        Me.Controls.Add(Me.ucrReceiverMeanRelativeHumidity)
        Me.Controls.Add(Me.ucrReceiverYear)
        Me.Controls.Add(Me.ucrSelectorExportToWWR)
        Me.Controls.Add(Me.ucrBase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgExportToWWR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export To World Weather Record"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents ucrSelectorExportToWWR As ucrSelectorByDataFrameAddRemove
    Friend WithEvents ucrReceiverYear As ucrReceiverSingle
    Friend WithEvents lblMeanRelativeHumidity As Label
    Friend WithEvents lblMeanDailyMaxAirTemperature As Label
    Friend WithEvents lblPrecipitation As Label
    Friend WithEvents lblMeanMonthlyAirTemperature As Label
    Friend WithEvents lblMeanSeaLevelPressure As Label
    Friend WithEvents lblMeanStationPressure As Label
    Friend WithEvents lblMonth As Label
    Friend WithEvents lblYear As Label
    Friend WithEvents lblMeanDailyMinAirTemperature As Label
    Friend WithEvents lblStationIdentifier As Label
    Friend WithEvents ucrReceiverMonth As ucrReceiverSingle
    Friend WithEvents ucrReceiverMeanStationPressure As ucrReceiverSingle
    Friend WithEvents ucrReceiverMeanDailyMaxAirTemperature As ucrReceiverSingle
    Friend WithEvents ucrReceiverMeanDailyMinAirTemperature As ucrReceiverSingle
    Friend WithEvents ucrReceiverMeanSeaLevelPressure As ucrReceiverSingle
    Friend WithEvents ucrReceiverMeanMonthlyAirTemperature As ucrReceiverSingle
    Friend WithEvents ucrReceiverPrecipitation As ucrReceiverSingle
    Friend WithEvents ucrReceiverMeanRelativeHumidity As ucrReceiverSingle
    Friend WithEvents btnStationMetadata As Button
    Friend WithEvents ucrInputLinkby As ucrInputComboBox
    Friend WithEvents cmdBrowse As Button
    Friend WithEvents ucrInputFilePath As ucrInputTextBox
    Friend WithEvents lblSaveFile As Label
    Friend WithEvents lblType As Label
    Friend WithEvents ucrReceiverStationIdentifier As ucrReceiverSingle
End Class

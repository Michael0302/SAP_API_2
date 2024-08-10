using CreateProjectNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SAP_WSDL_Library.Connected_Services.CreateProjectNS
{
    public class Sample
    {
        public static ZMaintainProjectAPICreateRequestMessage_sync Project = new ZMaintainProjectAPICreateRequestMessage_sync()
        {
            ZMaintainProjectAPI = new ZMaintainProjectAPICreateRequest()
            {
                ProjectName = new MEDIUM_Name()
                {
                    languageCode = "ZF",
                    Value = "BPM串接測試_2024042503"
                },
                LanguageCode = "ZF",
                ProjectID = new ProjectID()
                {
                    Value = "BPMTEST-2024042503"
                },
                TypeCode = new ProjectTypeCode()
                {
                    Value = "ZAIN"
                },
                StartAndReleaseIndicator = true,
                StartAndReleaseIndicatorSpecified = true,
                CustomerID = new PartyID()
                {
                    Value = "C002"
                },
                Task = [
                    new ZMaintainProjectAPICreateRequestTask(){
                        TaskID = "BPMTEST-2024042503",
                        TaskName = new MEDIUM_Name(){
                            languageCode = "ZF",
                            Value = "BPM串接測試_2024042503"
                        },
                        SummaryTaskIndicator = true,
                        SummaryTaskIndicatorSpecified = true,
                        ReleaseIndicator = true,
                        ReleaseIndicatorSpecified = true,
                        ResponsibleEmployeeID = new EmployeeID(){
                            Value = "E210902"
                        },
                        TimeRecord = "2",
                        WorkDescription = "1",
                        ExpenseReportAllowed = "1",
                        StartDate = new LOCALNORMALISED_DateTime(){
                            timeZoneCode = "UTC+8",
                            Value = Convert.ToDateTime("2024-04-25T00:00:00Z")
                        },
                        FinishDate = new LOCALNORMALISED_DateTime(){
                            timeZoneCode = "UTC+8",
                            Value = Convert.ToDateTime("2024-12-31T00:00:00Z")
                        },
                        ResponsibleUnitID = "DD30",
                        Attachment = new MaintenanceAttachmentFolder(){
                            ActionCode = ActionCode.Item01,
                            ActionCodeSpecified = true,
                            Document = [
                                new MaintenanceAttachmentFolderDocument(){
                                    ActionCode = ActionCode.Item01,
                                    ActionCodeSpecified = true,
                                    VisibleIndicator = true,
                                    VisibleIndicatorSpecified = true,
                                    CategoryCode = "3",
                                    TypeCode = new DocumentTypeCode(){
                                        Value = "10001"
                                    },
                                    Name = "BPM測試_專案",
                                    Description = new Description(){
                                        languageCode = "ZF",
                                        Value = "BPMTEST_Project_備註,BPM已全部簽核完成"
                                    },
                                    ExternalLinkWebURI = "https://www.ampower.com.tw/"
                                }
                            ]
                        },
                        Material = [
                            new ZMaintainProjectAPICreateRequestTaskMaterial(){
                                MaterialID = new ProductID(){
                                    Value = "CAXL3C0001"
                                },
                                FromStockIndicator = true,
                                FromStockIndicatorSpecified = true,
                                PlannedQuantity = new Quantity(){
                                    Value = 150,
                                    unitCode = "M"
                                }
                            },
                            new ZMaintainProjectAPICreateRequestTaskMaterial(){
                                MaterialID = new ProductID(){
                                    Value = "LVPNMF0016"
                                },
                                FromStockIndicator = true,
                                FromStockIndicatorSpecified = true,
                                PlannedQuantity = new Quantity(){
                                    Value = 22,
                                    unitCode = "EA"
                                }
                            }
                        ]
                    },
                    new ZMaintainProjectAPICreateRequestTask()
                    {
                        TaskID = "BPMTEST-2024042503-1",
                        TaskName = new MEDIUM_Name()
                        {
                            languageCode = "ZF",
                            Value = "BPM串接測試_2024042503-1"
                        },
                        SummaryTaskIndicator = false,
                        SummaryTaskIndicatorSpecified = true,
                        ParentTaskID = "BPMTEST-2024042503",
                        ReleaseIndicator = true,
                        ReleaseIndicatorSpecified = true,
                        ResponsibleEmployeeID = new EmployeeID()
                        {
                            Value = "E980501"
                        },
                        TimeRecord = "2",
                        WorkDescription = "1",
                        ExpenseReportAllowed = "1",
                        StartDate = new LOCALNORMALISED_DateTime()
                        {
                            timeZoneCode = "UTC+8",
                            Value = Convert.ToDateTime("2024-04-25T00:00:00Z")
                        },
                        FinishDate = new LOCALNORMALISED_DateTime()
                        {
                            timeZoneCode = "UTC+8",
                            Value = Convert.ToDateTime("2024-12-31T00:00:00Z")
                        },
                        Material = [
                            new ZMaintainProjectAPICreateRequestTaskMaterial()
                            {
                                MaterialID = new ProductID()
                                {
                                    Value = "BATWLT0006"
                                },
                                FromStockIndicator = true,
                                FromStockIndicatorSpecified = true,
                                PlannedQuantity = new Quantity()
                                {
                                    Value = 25,
                                    unitCode = "EA"
                                }
                            }
                        ]
                    },
                    new ZMaintainProjectAPICreateRequestTask()
                    {
                        TaskID = "BPMTEST-2024042503-2",
                        TaskName = new MEDIUM_Name()
                        {
                            languageCode = "ZF",
                            Value = "BPM串接測試_2024042503-2"
                        },
                        SummaryTaskIndicator = false,
                        SummaryTaskIndicatorSpecified = true,
                        ParentTaskID = "BPMTEST-2024042503",
                        ReleaseIndicator = true,
                        ReleaseIndicatorSpecified = true,
                        ResponsibleEmployeeID = new EmployeeID()
                        {
                            Value = "E040601"
                        },
                        TimeRecord = "2",
                        WorkDescription = "1",
                        ExpenseReportAllowed = "1",
                        StartDate = new LOCALNORMALISED_DateTime()
                        {
                            timeZoneCode = "UTC+8",
                            Value = Convert.ToDateTime("2024-04-25T00:00:00Z")
                        },
                        FinishDate = new LOCALNORMALISED_DateTime()
                        {
                            timeZoneCode = "UTC+8",
                            Value = Convert.ToDateTime("2024-12-31T00:00:00Z")
                        },
                        Material = [
                            new ZMaintainProjectAPICreateRequestTaskMaterial()
                            {
                                MaterialID = new ProductID()
                                {
                                    Value = "EXNE450007"
                                },
                                FromStockIndicator = true,
                                FromStockIndicatorSpecified = true,
                                PlannedQuantity = new Quantity()
                                {
                                    Value = 17,
                                    unitCode = "LS"
                                }
                            }
                        ]
                    },
                    new ZMaintainProjectAPICreateRequestTask()
                    {
                        TaskID = "BPMTEST-2024042503-2-1",
                        TaskName = new MEDIUM_Name()
                        {
                            languageCode = "ZF",
                            Value = "BPM串接測試_2024042502-2-1"
                        },
                        SummaryTaskIndicator = false,
                        SummaryTaskIndicatorSpecified = true,
                        ParentTaskID = "BPMTEST-2024042502-2",
                        ReleaseIndicator = true,
                        ReleaseIndicatorSpecified = true,
                        ResponsibleEmployeeID = new EmployeeID()
                        {
                            Value = "E040601"
                        },
                        TimeRecord = "2",
                        WorkDescription = "1",
                        ExpenseReportAllowed = "1",
                        StartDate = new LOCALNORMALISED_DateTime()
                        {
                            timeZoneCode = "UTC+8",
                            Value = Convert.ToDateTime("2024-04-25T00:00:00Z")
                        },
                        FinishDate = new LOCALNORMALISED_DateTime()
                        {
                            timeZoneCode = "UTC+8",
                            Value = Convert.ToDateTime("2024-12-31T00:00:00Z")
                        }
                    }
                ],
                TeamMember = [
                    new ZMaintainProjectAPICreateRequestTeamMember(){
                        EmployeeID = new EmployeeID(){
                            Value = "E040601"
                        },
                    },
                    new ZMaintainProjectAPICreateRequestTeamMember(){
                        EmployeeID = new EmployeeID(){
                            Value = "E980501"
                        },
                    },
                    new ZMaintainProjectAPICreateRequestTeamMember(){
                        EmployeeID = new EmployeeID(){
                            Value = "E210902"
                        },
                    },
                    new ZMaintainProjectAPICreateRequestTeamMember(){
                        EmployeeID = new EmployeeID(){
                            Value = "E020301"
                        },
                    }
                ]
            }
        };
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace UPExciseLTS.Models
{
    public class BrandMaster
    {
        public int BrandId { get; set; }
        public short BreweryId { get; set; }
        public string BrandName { get; set; }
        public string BrandRegistrationNumber { get; set; }
        public float Strength { get; set; }
        public string LiquorType { get; set; }
        public string LicenceType { get; set; }
        public string LicenceNo { get; set; }
        public string ExiciseTin { get; set; }
        public float MRP { get; set; }
        public float XFactoryPrice { get; set; }
        public float AdditionalDuty { get; set; }
        public int QuantityInCase { get; set; }
        public int QuantityInBottleML { get; set; }
        public float ExciseDuty { get; set; }
        public int ExportBoxSize { get; set; }
        public string Remark { get; set; }
    }
    public class Brewery
    {
        public short BreweryId { get; set; }
        public short DistrictCode { get; set; }
        public int TehsilCode { get; set; }
        public string BreweryName { get; set; }
        public string BreweryLicenseno { get; set; }
        public string BreweryAddress { get; set; }
        public string BreweryContactPerson { get; set; }
        public string BreweryContactPersonMobile { get; set; }
        public float BreweryCapacity { get; set; }
        public string BreweryPhone { get; set; }
        public string BreweryFax { get; set; }
        public string BreweryEmail { get; set; }
        public string Remark { get; set; }
    }
    public class BottelingPlan
    {
        [Display (Name="Plan Id")]
        public int PlanId { get; set; }
        [Display(Name = "Brewery Id")]
        public short BreweryId { get; set; }
        [Display(Name = "Production for State Code")]
        public short ProductionforStateCode { get; set; }
        [Display(Name = "Is State Same")]
        public bool IsStateSame { get; set; }
        [Display(Name = "Brand Id")]
        public int BrandId { get; set; }
        [Display(Name = "Number Of Cases")]
        public int NumberOfCases { get; set; }
        [Display(Name = "Qunatity In Case Export")]
        public int QunatityInCaseExport { get; set; }
        [Display(Name = "Bulk Liter")]
        public float BulkLiter { get; set; }
        [Display(Name = "Alcoholic Liter")]
        public float AlcoholicLiter { get; set; }
        [Display(Name = "Total Unit Quantity")]
        public int TotalUnitQuantity { get; set; }
        [Display(Name = "Plan Date")]
        public DateTime DateOfPlan { get; set; }
        [Display(Name = "Batch No")]
        public string BatchNo { get; set; }
        [Display(Name = "Mapped Unmapped")]
        public short MappedOrNot { get; set; }
        [Display(Name = "Is Plan Final")]
        public short IsPlanFinal { get; set; }
        [Display(Name = "Produced Number of cases")]
        public int ProducedNumberOfCases{ get; set; }
        [Display(Name = "Produced Quantity in case Export")]
        public float ProducedQunatityInCaseExport { get; set; }
        [Display(Name = "Produced Bulk Liter")]
        public float ProducedBulkLiter { get; set; }
        [Display(Name = "Produced Alcoholic Liter")]
        public int ProducedAlcoholicLiter { get; set; }
        [Display(Name = "Produced Total Unit Quantity")]
        public int ProducedTotalUnitQuantity { get; set; }
        [Display(Name = "Wastage in Number")]
        public int WastageInNumber { get; set; }
        [Display(Name = "Wastage BL")]
        public float WastageBL { get; set; }
        [Display(Name = "Is Production Final")]        
        public short IsProductionFinal { get; set; }
    }

}














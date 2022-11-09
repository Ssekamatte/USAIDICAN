using System;
using System.Collections.Generic;

#nullable disable

namespace USAIDICANBLAZOR.Models
{
    public partial class ViewEntreTrainingonNonAgricLivelihood
    {
        public double Id { get; set; }
        public string District { get; set; }
        public string Subcounty { get; set; }
        public string Village { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public int? Acty { get; set; }
        public string Tr { get; set; }
        public int? Totalnumber { get; set; }
        public string ActivityName { get; set; }
        public string TrainingName { get; set; }
        public double? MaleY { get; set; }
        public double? MaleA { get; set; }
        public double? FemaleY { get; set; }
        public double? FemaleA { get; set; }
        public string Region { get; set; }
    }
}

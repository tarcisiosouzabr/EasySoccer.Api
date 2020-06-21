﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EasySoccer.BLL.Infra.DTO
{
    public class FormInputCompanyEntryRequest
    {
        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string CompanyDocument { get; set; }

        public string CompanyName { get; set; }

        public string FinancialName { get; set; }

        public string FinancialDocument { get; set; }

        public string FinancialBirthDay { get; set; }

        public string CardNumber { get; set; }

        public string SecurityCode { get; set; }

        public string CardExpiration { get; set; }

        public int SelectedPlan { get; set; }

        public int SelectedInstallments { get; set; }
    }
}

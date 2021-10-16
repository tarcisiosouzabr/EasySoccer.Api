﻿using EasySoccer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasySoccer.BLL.Infra
{
    public interface IPaymentBLL
    {
        Task<Payment> CreateAsync(decimal value, Guid soccerPitchReservationId, Guid? personCompanyId, string note, int idFormOfPayment,long userId, long companyId);
        Task<Payment> UpdateAsync(long idPayment, decimal value, Guid? personCompanyId, string note, int formOfPaymentId);
        Task<List<Payment>> GetAsync(Guid soccerPitchReservationId);
    }
}
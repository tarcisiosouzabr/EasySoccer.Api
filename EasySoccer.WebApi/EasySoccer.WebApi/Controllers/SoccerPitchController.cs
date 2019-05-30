﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasySoccer.WebApi.ApiRequests;
using EasySoccer.WebApi.ApiRequests.Base;
using EasySoccer.WebApi.Controllers.Base;
using EasySoccer.WebApi.UoWs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasySoccer.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoccerPitchController : ApiBaseController
    {
        private SoccerPitchUoW _uow;
        public SoccerPitchController(SoccerPitchUoW uow) : base(uow)
        {
            _uow = uow;
        }


        [AllowAnonymous]
        [Route("get"), HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery]GetBaseRequest request)
        {
            try
            {
                return Ok((await _uow.SoccerPitchBLL.GetAsync(request.Page, request.PageSize)).Select(x => new
                {
                    x.Id,
                    x.Active,
                    x.Description,
                    x.HasRoof,
                    x.Name,
                    x.NumberOfPlayers
                }).ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [AllowAnonymous]
        [Route("post"), HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]SoccerPitchRequest request)
        {
            try
            {
                return Ok(await _uow.SoccerPitchBLL.CreateAsync(request.Name, request.Description, request.HasRoof, request.NumberOfPlayers, 1, request.Active, request.SoccerPitchPlanId));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [AllowAnonymous]
        [Route("patch"), HttpPatch]
        public async Task<IActionResult> PatchAsync([FromBody]SoccerPitchRequest request)
        {
            try
            {
                return Ok(await _uow.SoccerPitchBLL.UpdateAsync(request.Id, request.Name, request.Description, request.HasRoof, request.NumberOfPlayers, 1, request.Active, request.SoccerPitchPlanId));
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeltaBall.Data;
using DeltaBall.Data.Models;
using NuGet.Protocol.Core.Types;

namespace DeltaBall.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RankController : Controller
    {
        private readonly DataManager _dataManager;

        public RankController(DataManager context)
        {
            _dataManager = context;
        }
        public IActionResult Info()
        {
            ViewData["Title"] = "Таблица рангов";
            return View(_dataManager.Ranks.GetRanks());
        }

		public FileResult GetRankImage(int id)
		{
			var rank = _dataManager.Ranks.GetRankById(id);

			if (rank != null)
			{
				return File(rank.ImagePath, "image/" + rank.ImagePath.Split('.')[1]);
			}
			else
			{
				return null;
			}
		}
	}
}

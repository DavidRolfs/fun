using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FRPG.Controllers;
using FRPG.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace FRPG.Tests.ControllerTests
{
    
    public class PlayerControllerTest
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            PlayerController controller = new PlayerController(_userManager, _db);

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }
    }
}

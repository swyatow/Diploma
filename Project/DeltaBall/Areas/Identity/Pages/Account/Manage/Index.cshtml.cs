// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using DeltaBall.Data;
using DeltaBall.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeltaBall.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly DataManager _dataManager;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            DataManager dataManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dataManager = dataManager;
        }
        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Фамилия Имя Отчество")]
            public string UserName { get; set; }

            [Required]
            [Phone]
            [RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{9,9}$",
                   ErrorMessage = "Введеный номер телефона не подходит. Правильная форма: 8(123)456-78-90.")]
            [Display(Name = "Номер телефона")]
            public string PhoneNumber { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Адрес электронной почты")]
            public string Email { get; set; }
        }

        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var email = await _userManager.GetEmailAsync(user);

            //Username = userName;

            Input = new InputModel
            {
                UserName = userName,
                PhoneNumber = phoneNumber,
                Email = email
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Невозможно загрузить пользователя '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Невозможно загрузить пользователя '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            if(await _userManager.IsInRoleAsync(user, "Client"))
            {
				var client = _dataManager.Clients.GetClientById(Guid.Parse(user.Id));
				client.FullName = Input.UserName;
				client.PhoneNumber = Input.PhoneNumber;
				client.Email = Input.Email;

				if (await _dataManager.Clients.SaveClientAsync(client, null))
				{
					await _signInManager.RefreshSignInAsync(user);
					StatusMessage = "Ваши данные сохранены успешно.";
				}
				else
					StatusMessage = "Непредвиденная ошибка возникла при сохранении данных! Повторите позже.";
			}
			if ((await _userManager.SetUserNameAsync(user, Input.UserName)).Succeeded &&
				(await _userManager.SetEmailAsync(user, Input.Email)).Succeeded &&
				(await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber)).Succeeded)
            {				
				StatusMessage = "Ваши данные сохранены успешно.";
			}
			else
				StatusMessage = "Непредвиденная ошибка возникла при сохранении данных! Повторите позже.";

			await _userManager.UpdateNormalizedUserNameAsync(user);
			await _userManager.UpdateNormalizedEmailAsync(user);
			await _signInManager.RefreshSignInAsync(user);
			return RedirectToPage();
        }
    }
}

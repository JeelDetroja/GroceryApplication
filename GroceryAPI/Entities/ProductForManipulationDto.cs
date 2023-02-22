using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryAPI.Entities
{
    public class ProductForManipulationDto
    {
        [Key]
        public int ProductCategoryId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name must be fewer than 100 characters.")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Product Price")]
        public decimal ProductPrice { get; set; }
        [Range(0, 100)]
        [Display(Name = "Discount in (%)")]
        public virtual int? Discount { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "PhotoPath must be fewer than 500 characters.")]
        public string ProductPhotoPath { get; set; }
        [StringLength(500, ErrorMessage = "Discription must be fewer than 500 characters.")]
        public virtual string Description { get; set; }
        //public virtual DateTime CreatedOn { get; set; } = DateTime.Now;
        [Required]
        public int CreatedBy { get; set; }
        //public virtual DateTime UpdatedOn { get; set; } = DateTime.Now;
        [Required]
        public int UpdatedBy { get; set; }
        [Required]
        public bool isActivated { get; set; }

        //#region Photo Upload
        //[Required(ErrorMessage = "Please select a file.")]
        //[DataType(DataType.Upload)]
        //[MaxFileSize(5 * 1024 * 1024)]
        //[AllowedExtensions(new string[] { ".jpg", ".png" })]
        //public IFormFile Photo { get; set; }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> UploadPhoto(UserViewModel userViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var formFile = userViewModel.Photo;
        //        if (formFile == null || formFile.Length == 0)
        //        {
        //            ModelState.AddModelError("", "Uploaded file is empty or null.");
        //            return View(viewName: "Index");
        //        }

        //        var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "uploads");
        //        if (!Directory.Exists(uploadsRootFolder))
        //        {
        //            Directory.CreateDirectory(uploadsRootFolder);
        //        }

        //        var filePath = Path.Combine(uploadsRootFolder, formFile.FileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await formFile.CopyToAsync(fileStream).ConfigureAwait(false);
        //        }

        //        RedirectToAction("Index");
        //    }
        //    return View(viewName: "Index");
        //}
        //#endregion Photo Upload
    }
}

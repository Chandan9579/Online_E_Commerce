using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualBasic;
using UdemyDataAccess.Data;
using UdemyModels.Models;

namespace Udemy_Project.Controllers;

public class CategoryController : Controller
{
    // private readonly ILogger<CategoryController> _logger;

    // public CategoryController(ILogger<CategoryController> logger)
    // {
    //     _logger = logger;
    // }

    private readonly ApplicationDBContext _db;
    public CategoryController(ApplicationDBContext db)
    {
        _db = db;
    }

    

    public IActionResult Index()
    {

        List<Category> objCategoryList = _db.Chandan_Categories.ToList();
        return View(objCategoryList);
    }
    public IActionResult Create()
    {


        return View();
    }
    [HttpPost]
    public IActionResult Create(Category obj)
    {
        if( obj.Name==obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("Name", "Name and Display Order should not be same");
          
        }
    

          if(ModelState.IsValid)
          {_db.Chandan_Categories.Add(obj);
          _db.SaveChanges();
          return RedirectToAction("Index");
          }
          return View(obj);
    }   
  

    public IActionResult Edit(int? id)
    {
        if(id==null || id==0)
        {
            return NotFound();
        }

        Category categoryFromDb = _db.Chandan_Categories.Find(id);//used when we want to distinguish and filter based on primary key only
        Category categoryFromDb1 = _db.Chandan_Categories.FirstOrDefault(u=>u.Name=="akanksha"); //used when we want to extract only one specific row which can be a primary key or not. Here we can use other attributes apart from a primary key.
        Category categoryFromDb2 = _db.Chandan_Categories.Where(u=>u.Id==id).FirstOrDefault();//This method is used when there are multiple calculations involved.
        if(categoryFromDb==null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }


    [HttpPost]
    public IActionResult Edit(Category obj)
    {
          if(ModelState.IsValid)
          {
            _db.Chandan_Categories.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
          }
          return View(obj);
    }   
   
          
    



 public IActionResult Delete(int? id)
    {
        if(id==null || id==0)
        {
            return NotFound();
        }

        Category categoryFromDb = _db.Chandan_Categories.Find(id);//used when we want to distinguish and filter based on primary key only
        Category categoryFromDb1 = _db.Chandan_Categories.FirstOrDefault(u=>u.Name=="akanksha"); //used when we want to extract only one specific row which can be a primary key or not. Here we can use other attributes apart from a primary key.
        Category categoryFromDb2 = _db.Chandan_Categories.Where(u=>u.Id==id).FirstOrDefault();//This method is used when there are multiple calculations involved.
        if(categoryFromDb==null)
        {
            return NotFound();
        }
        
        return View(categoryFromDb);
    }


    [HttpPost,ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
          Category obj = _db.Chandan_Categories.Find(id);
          if(obj==null)
          {
            return NotFound();
          }
        //   _db.Chandan_Categories.Remove(obj);
        //   if(ModelState.IsValid)
        //   {
            _db.Chandan_Categories.Remove(obj);
            _db.SaveChanges();
            TempData["error"]="The Record was deleted successfully";
           

            
           
           

            return RedirectToAction("Index");
        //   }
        //   return View(obj);
    }   
   
          
    



}




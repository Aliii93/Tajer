using Microsoft.AspNetCore.Mvc;
using TajerTest.Models;
using TajerTest.Repository;

namespace TajerTest.Controllers
{
    public class BaseController : Controller
    {
        public static int userId = new();

        private TajerContext _context = new TajerContext();
        public Repository<Item> itemRepository;
        public BaseController()
        {
            itemRepository = new Repository<Item>(_context);
        }

    }
}

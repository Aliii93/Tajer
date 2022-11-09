using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using TajerTest.AuthFilter;
using TajerTest.InputsOutPuts;
using TajerTest.Models;

namespace TajerTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : BaseController
    {
        private readonly IMapper _mapper;
        public ItemController(IMapper mapper)
        {
            _mapper = mapper;
            
        }
        
        [AuthFilter.AuthFilter((int)Permissions.Read)]
        [HttpGet]
        [Route("[action]")]
        public List<ItemOutPut> GetItemList(Guid Id,string name, int enabledis)
        {
            List<Item> items = new List<Item>();
            if (enabledis == 1)
            {
                items = itemRepository.FindByCondition(x => x.IsActive == true).ToList();
            }
            else if(enabledis == 2)
            {
                items = itemRepository.FindByCondition(x => x.IsActive == false).ToList();
            }
            else
            {
                items = itemRepository.GetAll().ToList();
            }

            if (Id != Guid.Empty)
            {
                items = items.Where(x => x.ItemId == Id).ToList();
            }
            if (!string.IsNullOrEmpty(name))
            {
                items = items.Where(x => x.ItemName == name).ToList();
            }
            return _mapper.Map<List<ItemOutPut>>(items);
            
        }
        //Todo: rename (CustomItem) to ItemInput :Done
        //Todo: Rename (CustomModel Folder) to Inputs :Done
        //Todo: Rename the parameter to make it more understandable (itemInput) :Done
        // valedation on name and should be unique add price Parameter :Done
        //Todo: AutoMapper 1 item => input 2 item => output & Repository
        
        //[AuthFilter.AuthFilter((int)Permissions.Create)]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddItem([FromBody] ItemInput itemInput)
        {
           var item = itemRepository.FindByCondition(x => x.ItemName == itemInput.Name).FirstOrDefault();

            if (item != null)
            {
                return BadRequest("This Item Already Exist");
            }
            else
            {
                item = _mapper.Map<Item>(itemInput);
                itemRepository.Add(item);
                await itemRepository.SaveChangesAsync();
            }

            return Ok(item);
            
        }

        [AuthFilter.AuthFilter((int)Permissions.Update)]
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> EditItem(ItemInput itemUpdate)
        {
            var item = itemRepository.FindByCondition(x => x.ItemId == itemUpdate.Id && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
            if (item != null)
            {
                
                item = _mapper.Map<Item>(itemUpdate);
                itemRepository.Update(item);
                await itemRepository.SaveChangesAsync();
            }
            else
            {
                return BadRequest("Item Not Found");
            }
            return Ok(itemUpdate);
        }

        [AuthFilter.AuthFilter((int)Permissions.Update)]
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> DisableItem(Guid id)
        {
            var _item = itemRepository.FindByCondition(x => x.ItemId == id).FirstOrDefault();
            if (!_item.IsActive.GetValueOrDefault())
            {
                return BadRequest("This Item is Already Disabled");
                
            }
            else
            {
                _item.IsActive = false;
                itemRepository.Update(_item);
                await itemRepository.SaveChangesAsync();
                return Ok("Item Disabled Successfully");
                
            }
            
            
        }

        [AuthFilter.AuthFilter((int)Permissions.Update)]
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> EnableItem(Guid id)
        {
            var _item = itemRepository.FindByCondition(x => x.ItemId == id).FirstOrDefault();
            if (!_item.IsActive.GetValueOrDefault())
            {
                return BadRequest("This Item is Already enabled");

            }
            else
            {
                _item.IsActive = false;
                itemRepository.Update(_item);
                await itemRepository.SaveChangesAsync();
                return Ok("Item enabled Successfully");

            }
        }

        [AuthFilter.AuthFilter((int)Permissions.Update)]
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            var item = itemRepository.FindByCondition(x => x.ItemId == id && x.IsDeleted == false).FirstOrDefault();
            if (item != null)
            {
                itemRepository.Delete(item);
                await itemRepository.SaveChangesAsync();
                var itemOut = _mapper.Map<ItemOutPut>(item);
                return Ok(itemOut);
            }
            else
            {
                return BadRequest("Item Not Found");
            }
            
        }
    }
}

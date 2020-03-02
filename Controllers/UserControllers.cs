using BackStageCore3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackStageCore3.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserControllers : ControllerBase
    {
        private readonly DbModel _coreDbContext;

        public UserControllers(DbModel coreDbContext)
        {
            _coreDbContext = coreDbContext;
        }


        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<user>>> Get()
        {
            return await _coreDbContext.user.ToListAsync();
        }

        /// <summary>
        /// 查询type类型下的内容
        /// </summary>
        /// <returns>返回text</returns>
        [HttpGet("{机型}", Name = "机型2")]
        public List<user> Get(string 机型)
        {
            return _coreDbContext.Set<user>().Where(b => b.用户 == 机型).ToList();


        }


        /// <summary>
        /// 添加数据
        /// </summary>
        /// <returns></returns>
        // POST: api/Gj
        [HttpPost]
        public async Task<ActionResult<user>> Post(user gjs)
        {
            _coreDbContext.user.Add(gjs);
            await _coreDbContext.SaveChangesAsync();
            //CreatedAtAction(actionName,routeValues,value).
            return CreatedAtAction(nameof(Get), new { id = gjs.id }, gjs);
        }


        /// <summary>
        /// 按条件更新数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        // PUT: api/Gj/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, user item)
        {
            if (id != item.id)
            {
                return BadRequest();
            }
            _coreDbContext.Entry(item).State = EntityState.Modified;
            await _coreDbContext.SaveChangesAsync();

            return NoContent();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todoItem = await _coreDbContext.user.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            _coreDbContext.user.Remove(todoItem);
            await _coreDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}

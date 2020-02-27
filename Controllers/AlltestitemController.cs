﻿using BackStageCore3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackStageCore3.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AlltestitemController : ControllerBase
    {
        private readonly DbModel _coreDbContext;

        public AlltestitemController(DbModel coreDbContext)
        {
            _coreDbContext = coreDbContext;
        }


        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<alltestitem>>> Get()
        {
            return await _coreDbContext.alltestitem.ToListAsync();
        }

        /// <summary>
        /// 查询type类型下的内容
        /// </summary>
        /// <param name="id">条件</param>
        /// <returns>返回text</returns>
        [HttpGet("{机型}", Name = "机型")]
        public List<alltestitem> Get(string 机型)
        {
           return _coreDbContext.Set<alltestitem>().Where(b => b.机型== 机型).ToList();


        }


        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        // POST: api/Gj
        [HttpPost]
        public async Task<ActionResult<alltestitem>> Post(alltestitem gjs)
        {
            _coreDbContext.alltestitem.Add(gjs);
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
        public async Task<IActionResult> Put(int id, alltestitem item)
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
            var todoItem = await _coreDbContext.alltestitem.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            _coreDbContext.alltestitem.Remove(todoItem);
            await _coreDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}

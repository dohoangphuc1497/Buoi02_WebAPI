using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi02_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Buoi02_WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoaiController : ControllerBase
	{
		private readonly NhatNgheWebAPIContext _context;

		public LoaiController(NhatNgheWebAPIContext db)
		{
			_context = db;
		}

		[HttpGet]
		public async Task<IEnumerable<Loai>> GetAll()
		{
			return await _context.Loai.ToListAsync();
		}

		[HttpGet("{id}")]
		//host/api/Loai/1
		public async Task<Loai> GetById(int id)
		{
			return await _context.Loai.SingleOrDefaultAsync(p => p.MaLoai == id);
		}

		[HttpGet("search")]
		public async Task<IActionResult> Search(string keyword)
		{
			try
			{
				return Ok(await _context.Loai.Where(lo => lo.TenLoai.Contains(keyword)).ToListAsync());
			}
			catch
			{
				return NotFound();
			}

		}

		[HttpPost]
		public async Task<IActionResult> Create(Loai loai)
		{
			try
			{
				await _context.AddAsync(loai);
				await _context.SaveChangesAsync();
				return this.Created($"/{loai.MaLoai}", loai);
			}
			catch
			{
				return BadRequest();
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateLoai(int id, Loai loai)
		{
			if (id != loai.MaLoai)
			{
				return BadRequest();
			}
			var loaiDb = _context.Loai.SingleOrDefault(lo => lo.MaLoai == id);
			if (loaiDb == null)
			{
				return NotFound();
			}
			loaiDb.TenLoai = loai.TenLoai;
			loaiDb.MoTa = loai.MoTa;
			loaiDb.Hinh = loai.Hinh;
			await _context.SaveChangesAsync();
			return NoContent();

		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var loaiDb = _context.Loai.SingleOrDefault(lo => lo.MaLoai == id);
			if (loaiDb == null)
			{
				return NotFound();
			}
			try
			{
				_context.Remove(loaiDb);
				await _context.SaveChangesAsync();
				return NoContent();
			}
			catch (Exception ex)
			{
				return Ok(new
				{
					Success = false,
					Message = ex.Message
				});
			}
		}
	}
}

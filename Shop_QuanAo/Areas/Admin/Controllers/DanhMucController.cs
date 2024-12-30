using Microsoft.AspNetCore.Mvc;
using Shop_QuanAo.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Shop_QuanAo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        // Tiêm ApplicationDbContext vào controller
        public DanhMucController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetDanhMucList")]
        public async Task<IActionResult> GetDanhMucList()
        {
            try
            {
                using var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "GetDanhMucList";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Thêm tham số OUT SYS_REFCURSOR
                var cursorParam = new OracleParameter
                {
                    ParameterName = "p_cursor",
                    OracleDbType = OracleDbType.RefCursor,
                    Direction = System.Data.ParameterDirection.Output
                };
                command.Parameters.Add(cursorParam);

                // Thực thi stored procedure và đọc kết quả
                using var reader = await command.ExecuteReaderAsync();

                var danhMucList = new List<Danhmuc>();
                while (await reader.ReadAsync())
                {
                    danhMucList.Add(new Danhmuc
                    {
                        Iddanhmuc = reader.GetInt32(0),
                        Tendanhmuc = reader.GetString(1),
                        Mota = reader.IsDBNull(2) ? null : reader.GetString(2)
                    });
                }

                return Ok(danhMucList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Có lỗi xảy ra: " + ex.Message });
            }
        }


        [HttpPost("AddDanhMuc")]
        public async Task<IActionResult> AddDanhMuc([FromBody] Danhmuc danhmuc)
        {
            if (danhmuc == null)
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }

            // Kiểm tra xem danh mục đã tồn tại chưa
            var existingDanhMuc = await _context.Danhmucs
                .FirstOrDefaultAsync(d => d.Tendanhmuc == danhmuc.Tendanhmuc);

            if (existingDanhMuc != null)
            {
                return BadRequest("Danh mục đã tồn tại.");
            }

            try
            {
                // Gọi stored procedure AddDanhMuc
                var sqlCommand = "BEGIN AddDanhMuc(:p_TenDanhMuc, :p_MoTa); END;";

                await _context.Database.ExecuteSqlRawAsync(sqlCommand,
                    new OracleParameter("p_TenDanhMuc", danhmuc.Tendanhmuc),
                    new OracleParameter("p_MoTa", danhmuc.Mota ?? string.Empty));

                return Ok(new { Message = "Danh mục đã được thêm thành công." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Có lỗi xảy ra: " + ex.Message });
            }
        }
    }
}

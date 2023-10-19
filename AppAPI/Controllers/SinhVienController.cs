using Microsoft.AspNetCore.Mvc;
using AppData.Models;
using AppData.ManhNQ_PH21857;
namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        DBContextManhNQ context;
        public SinhVienController()
        {
            context = new DBContextManhNQ();
        }
        [HttpGet("Get-SinhVien")]
        public List<SinhVien> Get()
        {
            return context.sinhViens.ToList();
        }


        [HttpPost("Add-SinhVien")]
        public bool Post(SinhVien sinhVien)
        {
            try
            {
                sinhVien.Id = new Guid();
                context.sinhViens.Add(sinhVien);
                context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
           
        }

        // PUT api/<SinhVienController>/5
        [HttpPut("{id}")]
        public bool Update(Guid id,SinhVien sv)
        {
            try
            {
                var sv1 = context.sinhViens.FirstOrDefault(p => p.Id == id);
                if(sv1 == null)
                {
                    return false;
                }
                sv1.Email = sv.Email;
                sv1.Name = sv.Name;
                sv1.MaSV = sv.MaSV;
                sv1.NamSinh = sv.NamSinh;
                context.sinhViens.Update(sv1);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // DELETE api/<SinhVienController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            try
            {
                var sv1 = context.sinhViens.FirstOrDefault(p => p.Id == id);
                if (sv1 == null)
                {
                    return false;
                }
                sv1.TrangThai = false;
                context.sinhViens.Update(sv1);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

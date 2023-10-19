using Microsoft.AspNetCore.Mvc;
namespace AppAPI.Controllers
{
    public class MathController : Controller
    {
        [HttpGet("TinhToan")]
        public ActionResult TinhToan(float price, float voucher, float coupon)
        {
            return Ok(price*(1-coupon/100)-voucher);
        }
    }
}

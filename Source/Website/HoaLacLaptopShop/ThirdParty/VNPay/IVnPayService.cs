using HoaLacLaptopShop.Areas.Shared.ViewModels;

namespace HoaLacLaptopShop.ThirdParty.VNPay
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(HttpContext context, VnPayRequestModel model);
        VnPayResponseModel PaymentExecute(IQueryCollection collection);
    }
}

using DesignPattern.Mediator.MediatorPattern.Commands;
using DesignPattern.Mediator.MediatorPattern.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Mediator.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult> Index()
        {
            //send methodu bizden bir istek bekliyor , nereye istekte bulunacaksak orayı yazmam gerekir.
            var values = await _mediator.Send(new GetAllProductQuery());
            return View(values);
        }

        public async Task<ActionResult> GetProduct(int id)
        {
            var values = await _mediator.Send(new GetProductByIDQuery(id));
            return View(values);
        }

        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new RemoveProductCommand(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> UpdateProduct(int id)
        {
            var values = await _mediator.Send(new GetProductUpdateByIDQuery(id));
            return View(values);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateProduct(UpdateProductCommand updateProductCommand)
        {
            await _mediator.Send(updateProductCommand);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task< ActionResult> AddProduct(CreateProductCommand createProductCommand)
        {
            await _mediator.Send(createProductCommand);
            return RedirectToAction("Index");
        }


    }
}

using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("Pizza")]
public class WeatherForecastController : ControllerBase
{
    //Obter todas as pizzas
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();
    // Recuperando apenas uma pizza
    [HttpGet("Id")]
    public ActionResult<Pizza> Get(int id){
        var pizza = PizzaService.Get(id);
        if(pizza == null){
            return NotFound();
        }
        return pizza;
    }
    //Adicionar pizza
    [HttpPost]
    public IActionResult Create(Pizza pizza){
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new {id = pizza.Id}, pizza);
    }
    //Remover pizza
    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var pizza = PizzaService.Get(id);
        if(pizza is null){
            return  NotFound();
        }

        PizzaService.Delete(id);
            return NoContent();
    }
    //Modificar uma pizza 
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza){
        if(id != pizza.Id){
            return BadRequest();
        }
        var existingPizza = PizzaService.Get(id);
        if(existingPizza is null){
            return NotFound();
        }
        PizzaService.Update(pizza);


        return NoContent();
    }
}

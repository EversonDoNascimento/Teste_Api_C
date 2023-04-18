using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoPizza;

namespace ContosoPizza
{
    public class PizzaService
    {
        static List<Pizza> Pizzas{ get; }
        static int nextId = 3;
        //Constructor
        static PizzaService(){
            Pizzas = new List<Pizza>{
                new Pizza {
                    Id = 1,
                    Name = "Classic Italian",
                    IsGlutenFree = false,
                },

                new Pizza {
                    Id= 2,
                    Name = "Veggie",
                    IsGlutenFree = true,

                }
                
            };
        }
        //Methods
        public static List<Pizza> GetAll(){
            return Pizzas;
        }
        public static Pizza? Get(int id){
            return Pizzas.FirstOrDefault((p) => { return p.Id == id;});
        }
        public static void Add(Pizza pizza){
            pizza.Id = nextId++;
            Pizzas.Add(pizza);
        }
        public static void Delete(int id){
            var pizza = Get(id);
            if(pizza is null){
                return;
            }Pizzas.Remove(pizza);
        }

        public static void Update(Pizza pizza){
            var index = Pizzas.FindIndex((p)=>{return pizza.Id == p.Id;});
            if(index == -1){
                return;
            }
            Pizzas[index] = pizza;
        }

    }
}
using Microsoft.AspNetCore.Mvc;
using preceptors.Models;
using System.Text.Json;

namespace PerceptronAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerceptronController : ControllerBase
    {
        private readonly ModelParameters _parameters;

        public PerceptronController()
        {
            // Obtener la ruta completa del archivo
            string path = Path.Combine(Directory.GetCurrentDirectory(), "perceptron_params.json");

            // Verificar si el archivo existe en la ruta especificada
            if (System.IO.File.Exists(path))
            {
                Console.WriteLine("El archivo existe.");
            }
            else
            {
                Console.WriteLine("El archivo no existe en la ruta: " + path);
            }

            // Leer los parámetros del modelo desde el archivo JSON
            var jsonString = System.IO.File.ReadAllText(path);
            _parameters = JsonSerializer.Deserialize<ModelParameters>(jsonString);
        }

        [HttpPost("predict")]
        public IActionResult Predict([FromBody] FlowerInput input)
        {
            // Preparar el input con el bias
            var x = new double[] { 1, input.PetalLength, input.PetalWidth };
            var prediction = Predict(x);

            return Ok(new
            {
                isSetosa = prediction,
                className = prediction ? "Iris Setosa" : "No Iris Setosa"
            });
        }

        private bool Predict(double[] x)
        {
            var sum = 0.0;
            for (int i = 0; i < x.Length; i++)
            {
                sum += x[i] * _parameters.weights[i];
            }
            return sum > 0;
        }
    }
}

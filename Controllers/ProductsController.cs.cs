using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using e_commerce_api.Data;
using e_commerce_api.Models;

namespace e_commerce_api.Controllers
{
    [Route("api/[controller]")] // Define la ruta base para este controlador (ej: /api/products)
    [ApiController] // Indica que esta clase es un controlador de API y habilita convenciones de API
    public class ProductsController : ControllerBase // Clase base para controladores de API sin vista
    {
        private readonly ApplicationDbContext _context; // Campo para el contexto de la base de datos

        // Constructor: EF Core inyectará una instancia de ApplicationDbContext aquí
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        // Obtiene todos los productos de la base de datos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            // Retorna una lista de todos los productos.
            // ToListAsync() ejecuta la consulta y trae los datos de forma asíncrona.
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        // Obtiene un producto específico por su ID
        [HttpGet("{id}")] // Define que este método espera un parámetro 'id' en la ruta (ej: /api/products/1)
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            // Busca un producto por su ID de forma asíncrona.
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                // Si no se encuentra el producto, retorna un código de estado HTTP 404 Not Found.
                return NotFound();
            }

            // Si se encuentra el producto, lo retorna con un código de estado HTTP 200 OK.
            return product;
        }

        // POST: api/Products
        // Crea un nuevo producto
        // El cuerpo de la solicitud (Request Body) contendrá los datos del nuevo producto
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            // Agrega el nuevo producto al DbSet de Products en el contexto.
            _context.Products.Add(product);
            // Guarda los cambios en la base de datos de forma asíncrona.
            await _context.SaveChangesAsync();

            // Retorna un código de estado HTTP 201 CreatedAtAction, indicando que el recurso fue creado.
            // También incluye la URL para acceder al recurso recién creado y el objeto creado.
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // PUT: api/Products/5
        // Actualiza un producto existente
        // El 'id' en la ruta es el ID del producto a actualizar.
        // El cuerpo de la solicitud contendrá los datos actualizados del producto.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            // Si el ID de la ruta no coincide con el ID del producto en el cuerpo, es una solicitud incorrecta.
            if (id != product.Id)
            {
                return BadRequest(); // Retorna un código de estado HTTP 400 Bad Request.
            }

            // Marca el producto en el contexto como modificado.
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                // Intenta guardar los cambios en la base de datos.
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Maneja el caso en que el producto no existe en la base de datos.
                if (!ProductExists(id))
                {
                    return NotFound(); // Retorna 404 si el producto no se encuentra.
                }
                else
                {
                    // Si el producto existe pero hubo un problema de concurrencia, relanza la excepción.
                    throw;
                }
            }

            // Retorna un código de estado HTTP 204 No Content, indicando que la actualización fue exitosa sin contenido de retorno.
            return NoContent();
        }

        // DELETE: api/Products/5
        // Elimina un producto por su ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            // Busca el producto a eliminar.
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(); // Si no se encuentra, retorna 404.
            }

            // Elimina el producto del DbSet.
            _context.Products.Remove(product);
            // Guarda los cambios en la base de datos.
            await _context.SaveChangesAsync();

            // Retorna un código de estado HTTP 204 No Content.
            return NoContent();
        }

        // Método auxiliar para verificar si un producto existe (usado por PutProduct)
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
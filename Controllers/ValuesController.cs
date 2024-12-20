using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{

    [Route("api/VillaAPI")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;

        private readonly AplicationDbContext _db;
        private readonly IMapper    _mapper;

       
        public ValuesController(ILogger<ValuesController> logger , AplicationDbContext db,IMapper mapper)
        {
            _logger = logger; 
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult< IEnumerable<VillaDTO>>> GetVillas()
        {
            _logger.LogInformation("Get Villas");
            IEnumerable<Villa> villaList = await _db.Villas.ToListAsync();
            var model = _mapper.Map<IEnumerable<VillaDTO>>(villaList);

            return Ok(model);
        }


        [HttpGet("{id:int}" ,Name = "GetVilla")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]

        public async Task< ActionResult<VillaDTO>>GetVilla(int id) {


            if (id == 0) {

                _logger.LogError("Get Villa Error with" + id);
                return BadRequest();
            }
            var villa = await _db.Villas.FirstOrDefaultAsync(u => u.Id == id);

            if (villa == null) {
                return NotFound();
            }
            return Ok(_mapper.Map<VillaDTO>(villa));
        
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        public async Task< ActionResult<VillaDTO>> CreateVilla([FromBody]VillaDTOCreate createDTO) 
        
        {


            if (await _db.Villas.FirstOrDefaultAsync(u => u.Name.ToLower() == createDTO.Name.ToLower())!=null){

                ModelState.AddModelError("CustomError" , "Villa already Exist!");

                return BadRequest(ModelState);
            }


            if (createDTO== null) {

                return BadRequest(createDTO);
            }

 
           Villa model = _mapper.Map<Villa>(createDTO);
            
            await _db.Villas.AddAsync(model);
            await _db.SaveChangesAsync();


            return CreatedAtRoute("GetVilla", new {id = model.Id} , _mapper.Map<VillaDTO>(model));    

         }



        [HttpDelete("{id:int}", Name = "DeleteVilla")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task< IActionResult>DeleteVila(int id) {
            
            if(id == 0)
            {
                return BadRequest();
            }
            
            var villa = await _db.Villas.FirstOrDefaultAsync(u => u.Id == id);

            if (villa == null) {
                return NotFound();
            
            }
            _db.Villas.Remove(villa);
           await _db.SaveChangesAsync();


            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task <IActionResult>UpdateVilla(int id, [FromBody] VillaUpdateDTO updateDTO) {
        
            if (updateDTO == null || id != updateDTO.Id) {
            
            return BadRequest();
            }   


           Villa model = _mapper.Map<Villa>(updateDTO);

            _db.Villas.Update(model);
            await _db.SaveChangesAsync();
         
            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0 )
            {
                return BadRequest();
            }
           

            var villa = await _db.Villas.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

            if (villa == null)
            {
                return BadRequest();
            }

            VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa);
           
            

          

            patchDTO.ApplyTo(villaDTO , ModelState);

            Villa model = _mapper.Map<Villa>(villaDTO);
      

            _db.Update( model );

            await _db.SaveChangesAsync();

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }

}

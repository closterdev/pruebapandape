using Microsoft.AspNetCore.Mvc;
using Pandape.Business.Interfaces;
using Pandape.Data.Command;
using Pandape.Data.Dto;
using Pandape.Data.Query;

namespace Pandape.Service.Controllers
{
    /// <summary>
    /// Controlador para funcionalidad de Candidatos
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : Controller
    {
        private readonly ICommandHandler<CreateCandidateCommand, int> _createCandidateHandler;
        private readonly ICommandHandler<UpdateCandidateCommand, int> _updateCandidateHandler;
        private readonly ICommandHandler<DeleteCandidateCommand, int> _deleteCandidateHandler;
        private readonly IQueryHandler<GetCandidateQuery, CandidateDto> _getCandidateHandler;
        private readonly IQueryHandler<GetCandidatesQuery, List<CandidateDto>> _getCandidatesHandler;

        public CandidatesController(ICommandHandler<CreateCandidateCommand, int> createCandidateHandler,
            ICommandHandler<UpdateCandidateCommand, int> updateCandidateHandler,
            ICommandHandler<DeleteCandidateCommand, int> deleteCandidateHandler,
            IQueryHandler<GetCandidateQuery, CandidateDto> getCandidateHandler,
            IQueryHandler<GetCandidatesQuery, List<CandidateDto>> getCandidatesHandler)
        {
            _createCandidateHandler = createCandidateHandler;
            _updateCandidateHandler = updateCandidateHandler;
            _deleteCandidateHandler = deleteCandidateHandler;
            _getCandidateHandler = getCandidateHandler;
            _getCandidatesHandler = getCandidatesHandler;
        }

        /// <summary>
        /// Metodo para crear candidatos en BD
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateCandidate")]
        public async Task<IActionResult> CreateCandidate([FromBody] CreateCandidateCommand command)
        {
            int newCandidate = await _createCandidateHandler.Handle(command);
            return CreatedAtAction("GetCandidate", new { id = newCandidate });
        }

        /// <summary>
        /// Metodo para listar Candidato por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCandidate")]
        public async Task<IActionResult> GetCandidate(int id)
        {
            var query = new GetCandidateQuery { IdCandidate = id };
            var candidate = await _getCandidateHandler.Handle(query);

            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }

        /// <summary>
        /// Metodo para listar todos los Candidatos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCandidates")]
        public async Task<IActionResult> GetCandidates()
        {
            var query = new GetCandidatesQuery();
            var candidates = await _getCandidatesHandler.Handle(query);

            if (candidates == null)
            {
                return NotFound();
            }

            return Ok(candidates);
        }

        /// <summary>
        /// Metodo par actualizar Candidato por ID
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateCandidates")]
        public async Task<IActionResult> UpdateCandidates([FromBody] UpdateCandidateCommand command)
        {
            var candidate = await _updateCandidateHandler.Handle(command);
            return CreatedAtAction("GetCandidate", new { id = candidate });
        }

        /// <summary>
        /// Metodo para eliminar Candidado
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteCandidate")]
        public async Task<IActionResult> DeleteCandidate([FromBody] DeleteCandidateCommand command)
        {
            var candidate = await _deleteCandidateHandler.Handle(command);

            if (candidate == 0)
            {
                return Problem();
            }

            return Ok(candidate);
        }
    }
}

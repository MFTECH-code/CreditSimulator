using CreditSimulator.Domain.CreditSimulation;
using CreditSimulator.Domain.CreditSimulation.Abstractions;
using CreditSimulator.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CreditSimulator.API.Controllers.CreditSimulation;

[Route("CreditSimulation/[controller]")]
[ApiController]
public class CreditSimulatorController(ICreditSimulationService creditSimulationService) : ControllerBase
{
    /// <summary>
    /// Simulate Credit
    /// </summary>
    /// <param name="creditSimulationRequest">Input with info of client</param>
    /// <returns>Return installment values and proposed value.</returns>
    
    [HttpPost("/Simulate")]
    public IActionResult Simulate([FromBody] CreditSimulationRequest creditSimulationRequest)
    {
        try
        {
            return Ok(creditSimulationService.RunCreditSumulation(creditSimulationRequest));
        }
        catch (InsuficientException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace); 
            throw;
        }
    }
    
}

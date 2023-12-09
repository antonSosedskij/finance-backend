using finance_backend.API.Dto;

namespace finance_backend.Application.Services.Balance.Contracts
{
    public class UpdateBalanceResponse: ErrorResponse, SuccessResponse<BalanceView>
    {
        /// <summary>
        /// Получает или задает дополнительное сообщение об успешной операции регистрации.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Получает или задает данные успешной операции регистрации.
        /// </summary>
        public BalanceView Data { get; set; }
    }

}

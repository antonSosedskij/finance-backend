using finance_backend.API.Dto;

namespace finance_backend.Application.Services.Balance.Contracts
{
    public class GetBalanceResponse : ErrorResponse, SuccessResponse<BalanceView>
    {
        /// <summary>
        /// Получает или задает дополнительное сообщение об успешной операции получения баланса.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Получает или задает данные успешной операции получения баланса.
        /// </summary>
        public BalanceView Data { get; set; }
    }
}

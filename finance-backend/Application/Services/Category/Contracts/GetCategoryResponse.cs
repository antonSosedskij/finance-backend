using finance_backend.API.Dto;

namespace finance_backend.Application.Services.Category.Contracts
{
    public class GetCategoryResponse : ErrorResponse, SuccessResponse<CategoryView>
    {
        /// <summary>
        /// Получает или задает дополнительное сообщение об успешной операции регистрации.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Получает или задает данные успешной операции регистрации.
        /// </summary>
        public CategoryView? Data { get; set; }
    }
}

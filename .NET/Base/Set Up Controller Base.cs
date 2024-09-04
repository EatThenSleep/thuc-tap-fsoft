public class APiControllerBase{
    protected ApiResponse APIResponse<T>(T value){
        ApiResponse res = new()

        if(value == null){
            res.statusCode = HttpStatusCode.BadRequest;
            res.IsSuccess = false;
            res.ErrorMessages = value ?? new List<string>() { "Please try again" };
        }
        else{
            res.StatusCode = HttpStatusCode.OK;
            res.IsSuccess = true;
            res.Result = value.result;
        }

        return StatusCode(res.statusCode, res)
    }

    protected string getUserId() => HttpContext.GetUserId();
}

 public class ApiResponse
 {
     public HttpStatusCode StatusCode { get; set; }
     public bool IsSuccess { get; set; } = true;
     public List<string> ErrorMessages { get; set; } = new List<string>();
     public object? Result { get; set; }
 }
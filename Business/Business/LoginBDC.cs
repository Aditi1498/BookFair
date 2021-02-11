using Business.Validations;
using Shared;
using System;

namespace Business.Business
{
    public class LoginBDC : BDCBase, ILoginBDC
    {
        public LoginBDC() : base(BDCType.LoginBDC)
        {

        }

        public OperationResult<UserDTO> Login(UserDTO userDTO)
        {
            OperationResult<UserDTO> result = null;
            try
            {

                CustomValidationResult validationResult = Validator<SampleValidator, UserDTO>.Validate(userDTO, "SignUpValidation");
                if (validationResult.IsValid)
                {
                    IloginDAC signUpDAC = (IloginDAC)DACFactory.Instance.Create(DACType.LoginDAC);
                    UserDTO resultDTO = signUpDAC.Login(userDTO);
                    if (resultDTO != null)
                    {
                   
                    result = OperationResult<UserDTO>.CreateSuccessResult(resultDTO);
                    }
                    else
                    {
                        result = OperationResult<UserDTO>.CreateFailureResult("User With This email address does not exists");
                    }
                }
                else
                {
                    result = OperationResult<UserDTO>.CreateFailureResult(validationResult);
                }
            }
            catch (DACException dacEx)
            {
                result = OperationResult<UserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception e)
            {
                result = OperationResult<UserDTO>.CreateErrorResult(e.Message, e.StackTrace);
            }
            return result;
        }
    


        public OperationResult<UserDTO> SignUp(UserDTO userDTO)
        {
            OperationResult<UserDTO> result = null;
            try
            {

                CustomValidationResult validationResult = Validator<SampleValidator, UserDTO>.Validate(userDTO, "SignUpValidation");
                if (validationResult.IsValid)
                {
                    IloginDAC signUpDAC = (IloginDAC)DACFactory.Instance.Create(DACType.LoginDAC);
                    UserDTO resultDTO = signUpDAC.SignUp(userDTO);
                    if(resultDTO!=null)
                    {
                        result = OperationResult<UserDTO>.CreateSuccessResult(resultDTO);
                    }
                    else
                    {
                        result = OperationResult<UserDTO>.CreateFailureResult("User With This email address already exists");
                    }
                }
                else
                {
                    result = OperationResult<UserDTO>.CreateFailureResult(validationResult);
                }
            }
            catch(DACException dacEx)
            {
                result = OperationResult<UserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch(Exception e){
                result = OperationResult<UserDTO>.CreateErrorResult(e.Message, e.StackTrace);
            }
            return result;
        }
    }
}

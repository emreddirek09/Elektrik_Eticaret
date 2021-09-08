using System;

public class Bisiat
{
    public class Bisiat()
	{
		BisiatConnect data = new BisiatConnect();
    BisiatGetByToken.GetToken getByToken = new BisiatGetByToken.GetToken();
    IRestResponse response = data.GetByToken();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                getByToken = JsonConvert.DeserializeObject<BisiatGetByToken.GetToken>(response.Content);
                Token = getByToken.Message.Token;
            }
	}



}

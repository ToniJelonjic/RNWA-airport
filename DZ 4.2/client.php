<!DOCTYPE HTML>  
<html>
<head>
</head>
<body>  
<form action="" method="POST">
  Enter Amount:  <input type="text" name="amount">
  </br>
  </br>
  From:  <select name='cur1'>
			<option value="EUR">Euro</option>
			<option value="BAM" selected>BAM</option>
			<option value="USD">USD</option>
	   </select>
  To:  <select name='cur2'>
		<option value="EUR" selected>Euro</option>
		<option value="BAM">BAM</option>
		<option value="USD">USD</option>
	</select>
  </br>
  </br>
  <input type='submit' name='submit' value="CovertNow">
</form>
<?php


//header('Content-Type: text/plain');
try{
	ini_set('soap.wsdl_cache_enabled',0);
	ini_set('soap.wsdl_cache_ttl',0);
	
	//$endPointWSDL = "http://localhost/fsre/rnwa/web-servisi/primjer_1/hello.wsdl";
	$endPointWSDL = "http://localhost:44362/WebService1.asmx";
  
	$sClient = new SoapClient($endPointWSDL,
							array(
							'cache_wsdl'=>WSDL_CACHE_NONE,
							'trace' => 1)
							);
	  //primjer pokretanja bez dodatnih opcija
	  //$sClient = new SoapClient('hello.wsdl');
		//echo "Odgovor web servisa uz info o varijabli (var_dump)\n"; //mozeze komentirati
		if(isset($_POST['submit'])){
			$params = $_POST['amount'];
			$cur1 = $_POST['cur1'];
			$cur2 = $_POST['cur2'];
			$response = $sClient->moneyConvert($params,$cur1,$cur2);
			echo "<h2>Result: </h2>";
			print_r($response);
		}
		echo "\n\n";
		
		// 4 retka ispopd mozete komentirati, sluze za primjer kako izgeldaju req i res 
		//echo "SOAP REQUEST HEADERS:\n" . $sClient->__getLastRequestHeaders() . "\n";
		//echo "SOAP REQUEST :\n" . $sClient->__getLastRequest() . "\n";
		//echo "SOAP RESPONSE HEADERS:\n" . $sClient->__getLastResponseHeaders() . "\n";
		//echo "SOAP RESPONSE :\n" . $sClient->__getLastResponse() . "\n";
		
	  
		//var_dump($sClient->__getLastResponseHeaders());
		//var_dump($sClient->__getLastResponse());
		//$sClient->__getLastResponse();
  
	
  
  
  
  
} catch(SoapFault $e){
  var_dump($e);
  echo $e;
}

?>

</body>
</html>
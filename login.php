<?php
	$con = mysqli_connect('localhost', 'root', 'root','unityaccess');

	 //check that connection happen
	 if(mysqli_connect_errno())
	 {
	 	echo "1: connection failed"; //error code #1= connecttion failed
	 	exit();
	 }

	 $username = $_POST["name"];
	 $password = $_POST["password"];

	 //doublechecking if this name exists. we dont want that query yapcaz
	 $namecheckquery = "SELECT username, salt, hash, score FROM players WHERE username = '". $username . "';";

	 $namecheck = mysqli_query($con, $namecheckquery) or die ("2: name check query failed"); //error coe #2 = name check query failed
	 //only 1 tane name olmalı input ile
	 if(mysqli_num_rows($namecheck!= 1)){
	 	echo "5; EİTHER NO USER WİTH THİS NAME OR MORE THAN ONE"; //error code # 5: number of natcasesort(ames do not match)
	 	exit();
	 }


	 // get login info from query (fetch assosiative array like post array we can get info w these labels )
	 $existinginfo= mysqli_fetch_assoc($namecheck);
 
	 $salt = $existinginfo["salt"];
	 $hash = $existinginfo["hash"];

	 $loginhash = crypt($password, $salt);
	 if ($hash != $loginhash){
	 	echo "6: incorrect password"; //errorcode #6 = password does not hash to match table
	 	exit ();
	 }

	 echo "0 \t" . $existinginfo ["score"];






?>
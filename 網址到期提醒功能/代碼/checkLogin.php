<?php
if(isset($_POST['username']) && isset($_POST['password'])){
    //trim函數去除前後空格
    $username = trim($_POST['username']);       
    $password = trim($_POST['password']);      
    include_once('config.php');  //引入配置文件
    session_start();

    $limitNum = 3;  // 限制同個 IP 只能嘗試3次登入
    $userip = $_SERVER['REMOTE_ADDR']; //獲取當前使用者ip

    
    if (!isset($_SESSION["login_limit"])) { // 如果尚未寫入限制值
        if ($userip != $_SESSION["userip"]) { // 確認現在的 IP 跟之前可能存過的 IP 不同
            $_SESSION["login_limit"] = $limitNum; 
        }
    }
 
    if (!isset($_SESSION["userip"])) { // 如果尚未寫入使用者 IP
        $_SESSION["userip"] = $userip; // 將使用者 IP 存入 Session
    }

    //user表中查找輸入的用戶名和密碼是否匹配
    $sql = 'select * from users where user_name = :username and password = :password';
    $res = $pdo->prepare($sql);
    //綁定參數
    $res->bindParam(':username',$username);
    $res->bindParam(':password',$password);
    if($res->execute()){
        $rows = $res->fetch(PDO::FETCH_ASSOC);  //返回一個索引為結果集列名的陣列
        if($rows){       

            $_SESSION['username'] = $rows['user_name'];
            $_SESSION["login_limit"] = $limitNum;  // 登入成功將次數設回限制值     
            echo "<script>window.location.href='index.php'; </script>";

        } elseif($userip == $_SESSION["userip"]) {
            $_SESSION["login_limit"]--;
            if ($_SESSION["login_limit"] <= 0) { //如果嘗試次數用完，此 IP 將被紀錄到limit_ip資料表中限制登入
                $sql = "insert into limit_ip(ip) values(?);";
                $result = $pdo->prepare($sql);
                $result->execute([$userip]);
                echo "<script>alert('您的登入次數超過限制，已被限制登入！');document.location.href='login.php';</script>";

            } else {                 
                echo "<script>alert('用戶名或密碼錯誤，登錄失敗！');history.back();</script>";
   
            }    
        } else { // IP 不一樣就將次數設回限制值
            $_SESSION["userip"] = $userip;
            $_SESSION["login_limit"] = $limitNum;
            echo "<script>alert('用戶名或密碼錯誤，登錄失敗！');history.back();</script>";
            
        }
    } 
    
} else {  //如果不是POST提交，跳轉到登錄頁
    echo "<script>window.location.href='login.html'</script>";
}
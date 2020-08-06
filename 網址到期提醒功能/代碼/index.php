<?php

//使用seesion做登入判斷
session_start();

if(!isset($_SESSION['username'])){
    echo "<script>alert('請先登入');window.location.href='login.php'</script>";
}
//導入$pdo
include_once('config.php');

//查詢domain_web
$query1 = "select * from domain_web order by domain_id ;";
$result1 = $pdo->prepare($query1);
$result1->execute();
$rows1=$result1->fetchAll(PDO::FETCH_ASSOC);

//將domain_web的domain, domain_web以鍵值存入陣列
$domainArray =[];
foreach ($rows1 as  $value) {
    $domainArray[$value['domain']] = $value["domain_web"];
}

?> 
<!DOCTYPE html>
<style type="text/css">
	a{
		text-decoration:none;

	}
	/*預設的domain類樣式*/
	.domain0{
		color:skyblue;

	}
	.domain1{
		color:orange;
	}
	.domain2{
		color:pink;

	}
	.domain3{
		color:red;
	
	}
	.domain4{
		color:purple;

	}
	.domain5{
		color:gold;

	}
	.domain6{
		color:green;

	}							

	.DB{
		color:purple;

	}
	.phpMyAdmin{
		color:blue;

	}
	.dev{
		color:green;

 	}
 	.dev_webtitle{
        position: relative;
		color:#FFFF33;
		margin-right: 80px
	}
 	.dev_webtitle2{
		position: relative;
		color:#FFFF33;
		right: 235px;
	}	


	h3{
		color: white;

	}
    td h3 {
        margin-bottom : -7px;
    }
	.warning {
 		background-color:#FFFF00;
 		color: red;
	}
    table {
        /*position: relative;*/
        /*border: 1px solid red;*/
        /*right: -3px;*/
  		width: 40%;
    }

    .title {
        color:#FFFF33;
    }
</style>

<html>
	<head>
		<meta charest="utf-8"/>
		<title>整合式監控</title>
		<script  type="text/javascript" src="jquery-3.4.1.min.js"></script>
	</head>
	<body style="background-color:black;" >
        
	<?php

		//宣告網站到期剩餘天數陣列
		$expiryDateArray = []; 
        //此變量用來動態設置class名稱，搭配預設的domain類樣式
		$domainId = 0;
        //此變量用來動態設置class名稱
        $webId = 0;

        //第一個迴圈，遍歷網域domain
		foreach ($domainArray as $domain => $domainWeb) {
    		$query2 = "select * from domain where domain = ? order by id desc;";
    		$result2 = $pdo->prepare($query2);
    		$result2->execute([$domain]);
            //此處$j用來版面配置記數，每一列最多7個網址
    		$j = 1;

	?>
		
    		<div style="display: flex;justify-content: center;">
                <!-- domain class -->
    			<a class="domain<?= $domainId++; ?>" href="<?= $domainWeb;?>" target="_blank">
    				<h2><?= $domain;?></h2>
    			</a>
    		</div>
    		<div style="display: flex;justify-content: center;">	
    		<?php
            //此處$i用來版面配置記數，$i為1時不設置margin-left屬性
    		$i = 0;
            // 第二個迴圈，遍歷網域下的網站
    		while($row = $result2->fetch(PDO::FETCH_ASSOC)){ 
        		// 計算網頁到期天數並存入$expiryDateArray[]陣列
                $now = date_create();
                $expiryDate = date_create($row["expiry_date"]);
                $diff = date_diff($now, $expiryDate)->format("%R%a");
                $expiryDateArray[] = $diff;
            	$i++
        	?>      			
			<!-- $i為1時不設置margin-left屬性 -->
			<a href="http://<?= $row["web"];?>" target="_blank" style="margin-left :<?php if($i!=1) echo "20px";?>;"> 
                <!-- web class -->
				<h3 class='web<?= $webId++; ?>' ><?= $row["web"];?></h3>
			</a>
            <!-- $j用來版面配置記數，每一列最多7個網址 -->
			<?php if($j++%7==0) { ?>
				</div>
				<div style="display: flex;justify-content: center;">	
			
			<?php } ?>
		<?php } ?>
		</div>
	<!-- 網域分格線 -->
	<hr size="3" align="center" noshade width="50%" color="brown">
	<?php  } ?>
    
		<div style="display: flex;justify-content: center; ">
			<a  href="addDomain0.php" ><button>新增網域</button></a>
			<a  href="deleteDomain0.php" style="margin-left :20px"><button>移除網域</button></a>
			<a  href="addWeb0.php" style="margin-left :20px"><button>新增網址</button></a>
			<a  href="editDate2.php" style="margin-left :20px"><button>修改期限</button></a>
			<a  href="deleteWeb0.php" style="margin-left :20px"><button>移除網址</button></a>
			<a  href="backup.php" style="margin-left :20px"><button>備份</button></a>
			<a  href="showBackup.php" style="margin-left :20px"><button>套用備份</button></a>
		</div>
		<br>
		<div style="display: flex;justify-content: center; ">
			<a  href="logout.php" ><button >登出</button></a>
		</div>
		<br>
		<div style="display: flex;justify-content: center;">
			<a class="DB">
				<h2>DB主從監控</h2>
			</a>
		</div>
		<div style="display: flex;justify-content: center;">
			<a href="" target="_blank" style="margin-right: 20px;">
				<h3>台灣玩咖DB</h3>
			</a>
			<a href="" target="_blank" style="margin-right: 20px;">
				<h3>中國玩咖DB</h3>
			</a>
            <a href="" target="_blank" style="margin-right: 20px;">
                <h3>API DD-IN DB</h3>
            </a>
			<a href="" target="_blank">
				<h3>DEV測試環境DB</h3>
			</a>
		</div>
	<hr size="3" align="center" noshade width="50%" color="brown">
		<div style="display: flex;justify-content: center;">
			<a class="phpMyAdmin">
				<h2>phpMyAdmin</h2>
			</a>
		</div>
		<div style="display: flex;justify-content: center;">
			<a href="" target="_blank" style="margin-right: 20px;">
				<h3>DBinto</h3>
			</a>
			<a href="" target="_blank">
				<h3>devdb</h3>
			</a>
		</div>
            <hr size="3" align="center" noshade width="50%" color="brown">
            <div style="display: flex;justify-content: center;">
                <a class="dev">
                    <h2>DEV測試機網頁</h2>
                </a>
            </div>
		<table align="center"  cellpadding="0px">
            <tr>
                <td ><h3 class="title">Dev台灣玩咖</h3></td>
                <td><a href="" target="_blank" >
                    <h3>電腦版</h3></a>
                </td>
                <td><a href="" ><h3>iOS</h3></a></td>
                <td><a href="" ><h3>Android</h3></a></td>
                <td><a href="" ><h3>Simple</h3></a></td>
                <td><a href="" target="_blank">
                    	<h3>經銷商</h3>
                </a></td>
                <td><a href="" target="_blank">
                    	<h3>後台</h3>
                </a></td>
            </tr>
            <tr>
                <td><a>
                        <h3 class="title">Dev中國玩咖</h3>
                </a></td>

                <td><a href="" target="_blank" >
                        <h3 >電腦版</h3>
                </a></td>
                <td><a href="" target="_blank" >
                        <h3>iOS</h3>
                </a></td>
                <td><a href="" target="_blank" >
                        <h3>Android</h3>
                </a></td>
                <td><a href="" target="_blank" >
                        <h3>Simple</h3>
                </a></td>
                <td><a href="" target="_blank" >
                        <h3>運營商</h3>
                </a></td>
                <td><a href="" target="_blank">
                        <h3>後台</h3>
                </a></td>
            </tr>
            <tr>
                <td ><a>
                    <h3 class="title">DD-IN</h3>
                </a></td>
                <td><a class="domain" href="" target="_blank" >
                    <h3>首頁</h3>
                 </a></td>   
                <td><a class="domain" href="" target="_blank">
                    <h3>後台</h3>
                </a></td>
            </tr>
        </table >
        <!-- 有網頁快到期會播放音樂提醒 -->
        <div id="music"></div>



	</body>
</html>

<?php

// 將剩餘天數陣列轉成json格式
$jsonArray = json_encode($expiryDateArray);
 ?>

<script type="text/javascript">

	//此方法將快到期的網站添加警告樣式並播放音樂提醒
    $(document).ready(function(){
        var array = JSON.parse('<?= $jsonArray?>');
        var bool = false;

        // alert(array);
        for(var a = 0; a<array.length ; a++ ) {
            if(array[a] <= 2) {
            $(".web"+a).addClass("warning");
            bool = true;
            }            
        }
        // 添加音樂提醒
        // if(bool){
        //     var music = $("#music");
        //     music.append('<audio autoplay loop><source src="./sound/soccer.mp3" type="audio/mp3"></audio>');
            
        // }

    });
   
</script>

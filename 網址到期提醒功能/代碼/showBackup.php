<?php
session_start();
// 登入判斷
if(!isset($_SESSION['username'])){
    echo "<script>alert('請先登入');window.location.href='login.php'</script>";
}

//導入config
include_once('config.php');
//查詢domain_backup
$query1 = "select * from domain_backup order by create_date desc;";

$result1 = $pdo->prepare($query1);
$result1->execute();



?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>備份操作</title>
    <script  type="text/javascript" src="jquery-3.4.1.min.js"></script>
    <style type="text/css">
        th {
            color: #0a6999;

        }
        a {
            text-decoration : none;
        }
        .warning {
            background-color : #FFFF00;
        }

    </style>
</head>
<body>

<h3 align="center">備份操作</h3>

    <table align="center" border="2px" width="600" cellpadding="10" bgcolor="#fff8dc">
        <tr>
            <th>ID</th>
            <th width="150">創立時間</th>
            <th width="200">操作</th>
        </tr>
        <!--使用while，列出備份紀錄-->
        <?php while($row=$result1->fetch(PDO::FETCH_ASSOC)){  ?>
        
        <tr >
            <td><?= $row["id"];?></td>
            <td><?= $row["create_date"];?></td>

            <!-- 設置套用和刪除按鈕 -->
            <td>
                <button  onclick="location.href='replaceDomain.php?id=<?php echo $row['id'] ?>'">套用</button>                
                <button value="<?= $row['id'] ?>" onclick = "a(this)">刪除</button>                
            </td>
        </tr>
        <?php  } ?>
    </table><br> 
    <div align="center">     
		<button  onclick="location.href='index.php'">回首頁</button>
	</div>
</body>
</html>
<script type="text/javascript">
    // 確認刪除，用GET方法提交id値
	function a(obj) {
		var bool = confirm("確定刪除?");
		if(bool){
			var id = obj.value;
			window.location.href='deleteBackup.php?id='+id;
		}
	}
</script>
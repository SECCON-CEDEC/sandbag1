<?php
class Score extends Model
{
    public function getList($limit)
    {
        $sel = $this->select();
        $sel->order('point DESC,registed_time ASC');
		$sel->fields(array('name, point'));
		$sel->limit($limit);
        $rows = $sel->fetchAll();
		return $rows;
    }
    public function getEntry($uuid)
    {
        $sel = $this->select();
		$sel->where('uuid',$uuid);
        $rows = $sel->fetchRow();
		return $rows;		
	}
    public function getRank($point)
    {
		$db = Db::factory();
		$stmt = $db->query("SELECT COUNT(*) FROM score WHERE point>$point");
		$rows = $stmt->fetch(PDO::FETCH_NUM);
		return $rows[0];		
	}
    public function postEntry($data)
    {
		$param=array();
		foreach(array('uuid','name','point') as $i){
			$param[$i]=$data[$i];
		}
        $param['registed_time']=date('Y-m-d H:i:s');

        $ins = $this->insert();
		$ins->values($param);
		$ins->execute();
		$res = $this->getRank($data['point']);
		return $res;
	}
    public function updateEntry($data)
    {
		$param=array();
		foreach(array('name','point') as $i){
			$param[$i]=$data[$i];
		}
      	$param['registed_time']=date('Y-m-d H:i:s');
        $upd = $this->update();
        $upd->values($param);
        $upd->where('uuid', $data['uuid']);
        $upd->execute();
		$res = $this->getRank($data['point']);
		
		return $res;
	}
}

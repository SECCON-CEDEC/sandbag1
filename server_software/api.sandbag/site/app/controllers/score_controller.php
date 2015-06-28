<?php

class ScoreController extends RestController
{
    public function ranking()
    {
		//一覧の取得
		$model = $this->model('Score');
		$res = $model->getList(10);
        $this->response->json($res);        // JSON形式でレスポンス
    }
	public function rankingPost()
    {
        $params = $this->restParams;
		$model = $this->model('Score');

		$res = $model->getEntry($params[uuid]);
		if($res){
			//登録済み
			if($params['point']>$res['point']){//new record
				$rank = $model->updateEntry($params);
			}else{
				$rank = $model->getRank($res['point']);
			}
		}else{
			//新規
			$rank = $model->postEntry($params);
		}
        $this->response->json(array('rank'=>$rank));        // JSON形式でレスポンス
		
    }
}
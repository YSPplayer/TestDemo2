//接口中所有方法自动公开，不用显示指定 
pub trait CardTrait {
    fn id(&self) ->u32;
    fn name(&self) -> &str;
}
/*
规定卡片ID从10000开始依次递归
*/
pub struct Card {
    id:u32,//卡片ID
    name:String//卡片名称
}
impl Card {
    pub fn new(id:u32,name:String)-> Self {
        Card {
            id:id,
            name:name,
        }
    }
}
impl CardTrait for Card {
    fn id(&self) ->u32 {
        self.id
    }
    fn name(&self) -> &str {
        &self.name
    }
}
use super::card::{Card, CardTrait};

pub struct MonsterCard {
    card: Card,
    life: i32,
    attack: i32,
    defense: i32,
    shield: i32,
}

impl MonsterCard {
    pub fn new(id: u32, name: String, life: i32, attack: i32, defense: i32, shield: i32) -> Self {
        MonsterCard {
            card: Card::new(id, name),
            life,
            attack,
            defense,
            shield,
        }
    }
    
    pub fn get_life(&self) -> i32 {
        self.life
    }
    
    pub fn get_attack(&self) -> i32 {
        self.attack
    }
    
    pub fn get_defense(&self) -> i32 {
        self.defense
    }
    
    pub fn get_shield(&self) -> i32 {
        self.shield
    }
}

impl CardTrait for MonsterCard {
    fn id(&self) -> u32 {
        self.card.id()
    }
    
    fn name(&self) -> &str {
        self.card.name()
    }
}
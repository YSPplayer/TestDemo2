function initCard(args) {
    const card = {
        code:args.code,
        name:'职业小偷',
        type:CardType.Monster,
        description:'出牌阶段限一次，给予对方1000伤害',
        atk:5,
        hp:9,
        def:3,
        shd:3
    }
    console.log('exter')
    return card
}
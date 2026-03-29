export default class Util {
    constructor() {

    }
    static async LoadXml(path:string) {
        const response = await fetch(path);
        const xml = await response.text();
        return xml;
    }
    /**
     * 将 HTML 颜色字符串（如 "#447090"）转换为 Phaser 需要的数字色值
     */
    static ToColor(htmlColor: string): number {
        // 去掉 # 号
        if (htmlColor.startsWith('#')) {
            htmlColor = htmlColor.slice(1);
        }
        
        // 支持 #RGB 简写
        if (htmlColor.length === 3) {
            htmlColor = htmlColor.split('').map((c: string) => c + c).join('');
        }
        
        // 处理 8 位颜色值（包含 alpha 通道）
        if (htmlColor.length === 8) {
            // Phaser 颜色格式是 0xAARRGGBB，而输入是 RRGGBBAA
            const r = htmlColor.slice(0, 2);
            const g = htmlColor.slice(2, 4);
            const b = htmlColor.slice(4, 6);
            const a = htmlColor.slice(6, 8);
            htmlColor = a + r + g + b;
        }
        
        // 转为数字
        return parseInt(htmlColor, 16);
    }
}
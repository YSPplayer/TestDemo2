import { XMLParser } from 'fast-xml-parser';
import { XmlNode,filterKeys } from './xmldata';
export default class XmlFormat {
    parser: XMLParser;
    xml:string;
    node:XmlNode | null;
    constructor(xml:string) {
        this.parser = new XMLParser({
        ignoreAttributes: false,
        attributeNamePrefix: "",
        allowBooleanAttributes: true,
        parseTagValue: false, // 避免将空内容解析为空字符串
        trimValues: true, // 自动去除属性值周围的空格
        });
        this.xml = xml;
        this.node = null;
    }
    pushNode(data:any,parent:XmlNode | null) {
        if(!data) return;
        for(const key in data) {
            if(!filterKeys.includes(key)) continue;
            const node:XmlNode = {
                parent:parent,
                data:data[key],
                children:[],
                type:key
            };
            parent?.children.push(node);
            //this.data.push(node);
            this.pushNode(data[key],node);
        }
    }
    parse() {
        const data = this.parser.parse(this.xml);
        const body = data['body'];
        if(!data || !body) return;
        body.width = body.width || 1000;
        body.height = body.height || 1000;
        body.x = body.x || 0;
        body.y = body.y || 0;
        this.node = {
                parent:null,
                data:body,
                children:[],
                type:'body'
            };
        this.pushNode(body,this.node);
        console.log(this.node);
    }
}
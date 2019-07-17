// Shader created with Shader Forge v1.38
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:True,atwp:True,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:1873,x:33679,y:32541,varname:node_1873,prsc:2|emission-936-OUT,alpha-1156-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:32155,y:32436,ptovrint:False,ptlb:Texture_Masks,ptin:_Texture_Masks,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:2612a0b6893d8df4fb8e1ec2ff23b15a,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:5983,x:32159,y:32788,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.5,c3:0,c4:1;n:type:ShaderForge.SFN_Tex2d,id:4047,x:32159,y:32958,ptovrint:False,ptlb:Texture_Amount,ptin:_Texture_Amount,varname:node_4047,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:785d5667bf78b494bbee91c4d702eab3,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:8213,x:32528,y:32767,varname:node_8213,prsc:2|A-5983-RGB,B-1553-OUT,C-4805-G;n:type:ShaderForge.SFN_Add,id:1553,x:32381,y:32586,varname:node_1553,prsc:2|A-4805-R,B-4011-OUT;n:type:ShaderForge.SFN_Vector1,id:4011,x:32182,y:32659,varname:node_4011,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Slider,id:9475,x:32087,y:33346,ptovrint:False,ptlb:Amount,ptin:_Amount,varname:node_9475,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Add,id:2173,x:32414,y:32991,varname:node_2173,prsc:2|A-4047-R,B-4047-G,C-4047-B;n:type:ShaderForge.SFN_Multiply,id:4160,x:32589,y:32991,varname:node_4160,prsc:2|A-2173-OUT,B-6219-OUT;n:type:ShaderForge.SFN_Vector1,id:6219,x:32414,y:33120,varname:node_6219,prsc:2,v1:0.3333;n:type:ShaderForge.SFN_Subtract,id:2757,x:32741,y:33279,varname:node_2757,prsc:2|A-9475-OUT,B-4160-OUT;n:type:ShaderForge.SFN_Multiply,id:8744,x:32915,y:33279,varname:node_8744,prsc:2|A-2757-OUT,B-3894-OUT;n:type:ShaderForge.SFN_Vector1,id:4509,x:32590,y:33366,varname:node_4509,prsc:2,v1:1;n:type:ShaderForge.SFN_Divide,id:3894,x:32741,y:33413,varname:node_3894,prsc:2|A-4509-OUT,B-9475-OUT;n:type:ShaderForge.SFN_Time,id:5500,x:32620,y:31699,varname:node_5500,prsc:2;n:type:ShaderForge.SFN_Sin,id:7594,x:32991,y:31760,varname:node_7594,prsc:2|IN-3024-OUT;n:type:ShaderForge.SFN_Multiply,id:3024,x:32831,y:31760,varname:node_3024,prsc:2|A-5500-T,B-1661-OUT,C-7265-OUT;n:type:ShaderForge.SFN_Vector1,id:1661,x:32620,y:31854,varname:node_1661,prsc:2,v1:25;n:type:ShaderForge.SFN_Subtract,id:7778,x:32483,y:32101,varname:node_7778,prsc:2|A-6750-OUT,B-9475-OUT;n:type:ShaderForge.SFN_Vector1,id:6750,x:32272,y:32101,varname:node_6750,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:3095,x:32691,y:32101,varname:node_3095,prsc:2|A-7778-OUT,B-1466-OUT;n:type:ShaderForge.SFN_Vector1,id:1466,x:32470,y:32246,varname:node_1466,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Lerp,id:5235,x:33194,y:31977,varname:node_5235,prsc:2|A-2594-OUT,B-7103-OUT,T-882-OUT;n:type:ShaderForge.SFN_Vector1,id:2594,x:32991,y:32011,varname:node_2594,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:7103,x:33343,y:31760,varname:node_7103,prsc:2|A-9209-OUT,B-9795-OUT;n:type:ShaderForge.SFN_Vector1,id:8813,x:32991,y:31890,varname:node_8813,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:9209,x:33163,y:31760,varname:node_9209,prsc:2|A-7594-OUT,B-8813-OUT;n:type:ShaderForge.SFN_Vector1,id:9795,x:33163,y:31890,varname:node_9795,prsc:2,v1:1;n:type:ShaderForge.SFN_Clamp01,id:882,x:32891,y:32101,varname:node_882,prsc:2|IN-3095-OUT;n:type:ShaderForge.SFN_Power,id:7265,x:32620,y:31922,varname:node_7265,prsc:2|VAL-7778-OUT,EXP-3015-OUT;n:type:ShaderForge.SFN_Vector1,id:3015,x:32429,y:31976,varname:node_3015,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:9309,x:33244,y:33341,varname:node_9309,prsc:2|A-8744-OUT,B-9285-OUT;n:type:ShaderForge.SFN_Vector1,id:9285,x:32979,y:33476,varname:node_9285,prsc:2,v1:250;n:type:ShaderForge.SFN_Subtract,id:9914,x:32976,y:33007,varname:node_9914,prsc:2|A-2902-OUT,B-8744-OUT;n:type:ShaderForge.SFN_Vector1,id:2902,x:32817,y:33135,varname:node_2902,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Multiply,id:4825,x:33078,y:32798,varname:node_4825,prsc:2|A-5983-RGB,B-9914-OUT,C-5235-OUT,D-7900-OUT,E-4805-A;n:type:ShaderForge.SFN_Lerp,id:5238,x:32977,y:32566,varname:node_5238,prsc:2|A-4825-OUT,B-8213-OUT,T-4805-G;n:type:ShaderForge.SFN_Subtract,id:9535,x:32285,y:33593,varname:node_9535,prsc:2|A-9475-OUT,B-6615-OUT;n:type:ShaderForge.SFN_Vector1,id:6615,x:32087,y:33593,varname:node_6615,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:4677,x:32491,y:33593,varname:node_4677,prsc:2|A-9535-OUT,B-1738-OUT;n:type:ShaderForge.SFN_Vector1,id:1738,x:32285,y:33743,varname:node_1738,prsc:2,v1:1;n:type:ShaderForge.SFN_Clamp01,id:9548,x:32689,y:33593,varname:node_9548,prsc:2|IN-4677-OUT;n:type:ShaderForge.SFN_Add,id:7900,x:32878,y:33593,varname:node_7900,prsc:2|A-9548-OUT,B-908-OUT;n:type:ShaderForge.SFN_Vector1,id:908,x:32689,y:33758,varname:node_908,prsc:2,v1:1;n:type:ShaderForge.SFN_Subtract,id:3620,x:33269,y:33645,varname:node_3620,prsc:2|A-9948-OUT,B-8744-OUT;n:type:ShaderForge.SFN_Vector1,id:9948,x:33119,y:33734,varname:node_9948,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Min,id:5800,x:33439,y:33645,varname:node_5800,prsc:2|A-8744-OUT,B-3620-OUT;n:type:ShaderForge.SFN_Multiply,id:5554,x:33615,y:33645,varname:node_5554,prsc:2|A-5800-OUT,B-1864-OUT;n:type:ShaderForge.SFN_Vector1,id:1864,x:33439,y:33775,varname:node_1864,prsc:2,v1:5;n:type:ShaderForge.SFN_Add,id:936,x:33195,y:32611,varname:node_936,prsc:2|A-5238-OUT,B-1146-OUT;n:type:ShaderForge.SFN_Clamp01,id:1146,x:33803,y:33645,varname:node_1146,prsc:2|IN-5554-OUT;n:type:ShaderForge.SFN_Clamp01,id:6453,x:33391,y:33212,varname:node_6453,prsc:2|IN-9309-OUT;n:type:ShaderForge.SFN_Multiply,id:4879,x:33579,y:33212,varname:node_4879,prsc:2|A-6453-OUT,B-4805-A;n:type:ShaderForge.SFN_Add,id:1156,x:33387,y:32900,varname:node_1156,prsc:2|A-4805-B,B-4879-OUT,C-3192-OUT;n:type:ShaderForge.SFN_Slider,id:3192,x:33340,y:32429,ptovrint:False,ptlb:Test,ptin:_Test,varname:node_3192,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;proporder:4805-5983-9475-4047-3192;pass:END;sub:END;*/

Shader "Shader Forge/UI" {
    Properties {
        _Texture_Masks ("Texture_Masks", 2D) = "white" {}
        _Color ("Color", Color) = (1,0.5,0,1)
        _Amount ("Amount", Range(0, 1)) = 0.5
        _Texture_Amount ("Texture_Amount", 2D) = "white" {}
        _Test ("Test", Range(0, 1)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
        _MainTex ("Texture", 2D) = "white"
        _Stencil ("Stencil ID", Float) = 0
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilComp ("Stencil Comparison", Float) = 8
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilOpFail ("Stencil Fail Operation", Float) = 0
        _StencilOpZFail ("Stencil Z-Fail Operation", Float) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off

            Stencil {
                Ref [_Stencil]
                ReadMask [_StencilReadMask]
                WriteMask [_StencilWriteMask]
                Comp [_StencilComp]
                Pass [_StencilOp]
                Fail [_StencilOpFail]
                ZFail [_StencilOpZFail]
            }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            //#define UNITY_PASS_FORWARDBASE
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles
            #pragma target 3.0
            uniform sampler2D _Texture_Masks; uniform float4 _Texture_Masks_ST;
            uniform float4 _Color;
            uniform sampler2D _Texture_Amount; uniform float4 _Texture_Amount_ST;
            uniform float _Amount;
            uniform float _Test;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _Texture_Amount_var = tex2D(_Texture_Amount,TRANSFORM_TEX(i.uv0, _Texture_Amount));
                float node_8744 = ((_Amount-((_Texture_Amount_var.r+_Texture_Amount_var.g+_Texture_Amount_var.b)*0.3333))*(1.0/_Amount));
                float4 node_5500 = _Time;
                float node_7778 = (1.0-_Amount);
                float4 _Texture_Masks_var = tex2D(_Texture_Masks,TRANSFORM_TEX(i.uv0, _Texture_Masks));
                float3 emissive = (lerp((_Color.rgb*(1.5-node_8744)*lerp(1.0,((sin((node_5500.g*25.0*pow(node_7778,2.0)))*0.5)+1.0),saturate((node_7778*0.5)))*(saturate(((_Amount-0.0)*1.0))+1.0)*_Texture_Masks_var.a),(_Color.rgb*(_Texture_Masks_var.r+0.5)*_Texture_Masks_var.g),_Texture_Masks_var.g)+saturate((min(node_8744,(0.1-node_8744))*5.0)));
                float3 finalColor = emissive;
                return fixed4(finalColor,(_Texture_Masks_var.b+(saturate((node_8744*250.0))*_Texture_Masks_var.a)+_Test));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

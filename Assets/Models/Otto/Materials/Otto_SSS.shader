// Shader created with Shader Forge v1.38
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:1,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|normal-5353-RGB,lwrap-8364-RGB,difocc-4051-R,spcocc-4051-R,custl-565-OUT;n:type:ShaderForge.SFN_Tex2d,id:1546,x:33347,y:32003,ptovrint:False,ptlb:BaseColor,ptin:_BaseColor,varname:node_1546,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:54bbca7ae723ac04f9e947001e70bd57,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5353,x:32245,y:32784,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_5353,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c48fb049779234742a17514944ecad6d,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:4051,x:33347,y:31814,ptovrint:False,ptlb:AO,ptin:_AO,varname:node_4051,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:81ae15997cb9d9e429a8bedf6099d2a4,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8364,x:33146,y:32096,ptovrint:False,ptlb:Transmission,ptin:_Transmission,varname:node_8364,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:78358780d5b46ff4d822cc40aec67e32,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9597,x:32664,y:31827,ptovrint:False,ptlb:Curvature,ptin:_Curvature,varname:node_9597,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ad34d2bca67b615439f6608dd7a30498,ntxv:0,isnm:False;n:type:ShaderForge.SFN_NormalVector,id:2589,x:32739,y:32247,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:4908,x:32739,y:32388,varname:node_4908,prsc:2;n:type:ShaderForge.SFN_ViewVector,id:9435,x:32739,y:32516,varname:node_9435,prsc:2;n:type:ShaderForge.SFN_Dot,id:8239,x:33003,y:32246,varname:node_8239,prsc:2,dt:0|A-2589-OUT,B-4908-OUT;n:type:ShaderForge.SFN_Dot,id:972,x:32997,y:32519,varname:node_972,prsc:2,dt:0|A-2589-OUT,B-9435-OUT;n:type:ShaderForge.SFN_Multiply,id:199,x:33247,y:32256,varname:node_199,prsc:2|A-8239-OUT,B-3587-OUT;n:type:ShaderForge.SFN_Add,id:6442,x:33457,y:32256,varname:node_6442,prsc:2|A-199-OUT,B-2972-OUT;n:type:ShaderForge.SFN_Vector1,id:3587,x:33136,y:32378,varname:node_3587,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Vector1,id:2972,x:33336,y:32378,varname:node_2972,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:9733,x:33229,y:32527,varname:node_9733,prsc:2|A-972-OUT,B-9671-OUT;n:type:ShaderForge.SFN_Vector1,id:9671,x:33118,y:32649,varname:node_9671,prsc:2,v1:0.8;n:type:ShaderForge.SFN_Append,id:5599,x:33624,y:32406,varname:node_5599,prsc:2|A-9733-OUT,B-6442-OUT;n:type:ShaderForge.SFN_Tex2d,id:6102,x:33792,y:32453,ptovrint:False,ptlb:SSS_Ramp,ptin:_SSS_Ramp,varname:node_6102,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b0bdd1290b57b984f9b1567007d48e3b,ntxv:0,isnm:False|UVIN-5599-OUT;n:type:ShaderForge.SFN_Multiply,id:8343,x:34407,y:32474,varname:node_8343,prsc:2|A-2814-OUT,B-3738-RGB,C-2647-OUT,D-757-OUT;n:type:ShaderForge.SFN_LightColor,id:3738,x:33792,y:32619,varname:node_3738,prsc:2;n:type:ShaderForge.SFN_LightAttenuation,id:2647,x:33803,y:32752,varname:node_2647,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1662,x:34012,y:32359,varname:node_1662,prsc:2|A-6102-R,B-8364-R,C-757-OUT,D-2350-OUT;n:type:ShaderForge.SFN_Lerp,id:2814,x:34205,y:32223,varname:node_2814,prsc:2|A-8687-OUT,B-5170-OUT,T-1662-OUT;n:type:ShaderForge.SFN_Power,id:8687,x:33842,y:31954,varname:node_8687,prsc:2|VAL-1546-RGB,EXP-2243-OUT;n:type:ShaderForge.SFN_Vector1,id:2243,x:33647,y:31988,varname:node_2243,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:7957,x:33647,y:32170,varname:node_7957,prsc:2|A-1546-RGB,B-8364-R;n:type:ShaderForge.SFN_Add,id:5170,x:33809,y:32111,varname:node_5170,prsc:2|A-1546-RGB,B-7957-OUT;n:type:ShaderForge.SFN_Power,id:757,x:33746,y:31764,varname:node_757,prsc:2|VAL-4051-R,EXP-1951-OUT;n:type:ShaderForge.SFN_Vector1,id:1951,x:33551,y:31798,varname:node_1951,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:2350,x:33936,y:32491,varname:node_2350,prsc:2,v1:2;n:type:ShaderForge.SFN_Add,id:565,x:34549,y:32356,varname:node_565,prsc:2|A-8343-OUT,B-7404-OUT;n:type:ShaderForge.SFN_Power,id:7404,x:34365,y:32824,varname:node_7404,prsc:2|VAL-6102-B,EXP-8710-OUT;n:type:ShaderForge.SFN_Vector1,id:8710,x:34170,y:32858,varname:node_8710,prsc:2,v1:4;proporder:1546-4051-5353-8364-9597-6102;pass:END;sub:END;*/

Shader "Shader Forge/Otto_SSS" {
    Properties {
        _BaseColor ("BaseColor", 2D) = "white" {}
        _AO ("AO", 2D) = "white" {}
        _Normal ("Normal", 2D) = "bump" {}
        _Transmission ("Transmission", 2D) = "white" {}
        _Curvature ("Curvature", 2D) = "white" {}
        _SSS_Ramp ("SSS_Ramp", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }


            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles
            #pragma target 3.0
            uniform sampler2D _BaseColor; uniform float4 _BaseColor_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _AO; uniform float4 _AO_ST;
            uniform sampler2D _Transmission; uniform float4 _Transmission_ST;
            uniform sampler2D _SSS_Ramp; uniform float4 _SSS_Ramp_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _BaseColor_var = tex2D(_BaseColor,TRANSFORM_TEX(i.uv0, _BaseColor));
                float4 _Transmission_var = tex2D(_Transmission,TRANSFORM_TEX(i.uv0, _Transmission));
                float2 node_5599 = float2((dot(i.normalDir,viewDirection)*0.8),((dot(i.normalDir,lightDirection)*0.3)+0.5));
                float4 _SSS_Ramp_var = tex2D(_SSS_Ramp,TRANSFORM_TEX(node_5599, _SSS_Ramp));
                float4 _AO_var = tex2D(_AO,TRANSFORM_TEX(i.uv0, _AO));
                float node_757 = pow(_AO_var.r,0.5);
                float3 finalColor = ((lerp(pow(_BaseColor_var.rgb,2.0),(_BaseColor_var.rgb+(_BaseColor_var.rgb*_Transmission_var.r)),(_SSS_Ramp_var.r*_Transmission_var.r*node_757*2.0))*_LightColor0.rgb*attenuation*node_757)+pow(_SSS_Ramp_var.b,4.0));
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One


            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            //#define UNITY_PASS_FORWARDADD
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles
            #pragma target 3.0
            uniform sampler2D _BaseColor; uniform float4 _BaseColor_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform sampler2D _AO; uniform float4 _AO_ST;
            uniform sampler2D _Transmission; uniform float4 _Transmission_ST;
            uniform sampler2D _SSS_Ramp; uniform float4 _SSS_Ramp_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                UNITY_FOG_COORDS(7)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _BaseColor_var = tex2D(_BaseColor,TRANSFORM_TEX(i.uv0, _BaseColor));
                float4 _Transmission_var = tex2D(_Transmission,TRANSFORM_TEX(i.uv0, _Transmission));
                float2 node_5599 = float2((dot(i.normalDir,viewDirection)*0.8),((dot(i.normalDir,lightDirection)*0.3)+0.5));
                float4 _SSS_Ramp_var = tex2D(_SSS_Ramp,TRANSFORM_TEX(node_5599, _SSS_Ramp));
                float4 _AO_var = tex2D(_AO,TRANSFORM_TEX(i.uv0, _AO));
                float node_757 = pow(_AO_var.r,0.5);
                float3 finalColor = ((lerp(pow(_BaseColor_var.rgb,2.0),(_BaseColor_var.rgb+(_BaseColor_var.rgb*_Transmission_var.r)),(_SSS_Ramp_var.r*_Transmission_var.r*node_757*2.0))*_LightColor0.rgb*attenuation*node_757)+pow(_SSS_Ramp_var.b,4.0));
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}

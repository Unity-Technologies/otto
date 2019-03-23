// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:1,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-5377-OUT,spec-358-OUT,gloss-4608-OUT,normal-743-RGB,emission-5728-OUT,transm-9448-G,difocc-9448-R,spcocc-9448-R;n:type:ShaderForge.SFN_Multiply,id:6343,x:32014,y:32572,varname:node_6343,prsc:2|A-6481-OUT,B-9448-G;n:type:ShaderForge.SFN_Slider,id:358,x:32321,y:33145,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Vector1,id:6481,x:31803,y:32572,varname:node_6481,prsc:2,v1:0.25;n:type:ShaderForge.SFN_Tex2d,id:743,x:32541,y:33288,ptovrint:False,ptlb:Texture_Normal,ptin:_Texture_Normal,varname:node_743,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:138bb1b9c66b2f34c92cc1bd2d761b60,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:9448,x:31814,y:32728,ptovrint:False,ptlb:Texture_Masks,ptin:_Texture_Masks,varname:node_9448,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:64aeb3532758cdd4eb734e11d7f62b56,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:445,x:32183,y:32644,varname:node_445,prsc:2|A-6343-OUT,B-1709-OUT;n:type:ShaderForge.SFN_Vector1,id:1709,x:32014,y:32704,varname:node_1709,prsc:2,v1:0.1;n:type:ShaderForge.SFN_FragmentPosition,id:7126,x:32315,y:32266,varname:node_7126,prsc:2;n:type:ShaderForge.SFN_Distance,id:3940,x:32489,y:32320,varname:node_3940,prsc:2|A-7126-XYZ,B-1002-OUT;n:type:ShaderForge.SFN_Vector3,id:1002,x:32315,y:32396,varname:node_1002,prsc:2,v1:0,v2:0,v3:0;n:type:ShaderForge.SFN_Vector1,id:6099,x:32489,y:32248,varname:node_6099,prsc:2,v1:25;n:type:ShaderForge.SFN_Subtract,id:9993,x:32680,y:32278,varname:node_9993,prsc:2|A-6099-OUT,B-3940-OUT;n:type:ShaderForge.SFN_Clamp01,id:3156,x:33003,y:32279,varname:node_3156,prsc:2|IN-3666-OUT;n:type:ShaderForge.SFN_Multiply,id:5377,x:32376,y:32644,varname:node_5377,prsc:2|A-4672-RGB,B-6229-OUT,C-445-OUT,D-9879-OUT;n:type:ShaderForge.SFN_Add,id:7474,x:33152,y:32379,varname:node_7474,prsc:2|A-3156-OUT,B-4460-OUT;n:type:ShaderForge.SFN_Vector1,id:4460,x:32991,y:32482,varname:node_4460,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Color,id:4672,x:31954,y:32374,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_4672,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:9879,x:31958,y:32251,ptovrint:False,ptlb:Color_Multiplier,ptin:_Color_Multiplier,varname:node_9879,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:2;n:type:ShaderForge.SFN_Slider,id:8967,x:32022,y:33061,ptovrint:False,ptlb:Roughness_Offset,ptin:_Roughness_Offset,varname:node_8967,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Subtract,id:7023,x:32100,y:32921,varname:node_7023,prsc:2|A-904-OUT,B-9448-B;n:type:ShaderForge.SFN_Vector1,id:904,x:32022,y:32821,varname:node_904,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:9836,x:32294,y:32866,varname:node_9836,prsc:2|A-7023-OUT,B-8186-OUT;n:type:ShaderForge.SFN_Add,id:5112,x:32399,y:32992,varname:node_5112,prsc:2|A-9836-OUT,B-8967-OUT;n:type:ShaderForge.SFN_Vector1,id:8186,x:32209,y:32992,varname:node_8186,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Clamp01,id:4608,x:32529,y:32876,varname:node_4608,prsc:2|IN-5112-OUT;n:type:ShaderForge.SFN_Fresnel,id:6890,x:33010,y:32605,varname:node_6890,prsc:2;n:type:ShaderForge.SFN_Slider,id:4058,x:32909,y:32822,ptovrint:False,ptlb:Fresnel_Multiplier,ptin:_Fresnel_Multiplier,varname:node_4058,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;n:type:ShaderForge.SFN_Multiply,id:5728,x:33204,y:32669,varname:node_5728,prsc:2|A-6890-OUT,B-4058-OUT,C-5377-OUT;n:type:ShaderForge.SFN_Vector1,id:6930,x:33152,y:32313,varname:node_6930,prsc:2,v1:1;n:type:ShaderForge.SFN_Lerp,id:6229,x:33332,y:32313,varname:node_6229,prsc:2|A-6930-OUT,B-7474-OUT,T-6322-OUT;n:type:ShaderForge.SFN_Slider,id:6322,x:33125,y:32538,ptovrint:False,ptlb:Use_WS_Position,ptin:_Use_WS_Position,varname:node_6322,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Divide,id:3666,x:32840,y:32279,varname:node_3666,prsc:2|A-9993-OUT,B-6099-OUT;proporder:358-743-9448-4672-9879-8967-4058-6322;pass:END;sub:END;*/

Shader "Shader Forge/FloorTiles" {
    Properties {
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Texture_Normal ("Texture_Normal", 2D) = "bump" {}
        _Texture_Masks ("Texture_Masks", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _Color_Multiplier ("Color_Multiplier", Range(0, 2)) = 1
        _Roughness_Offset ("Roughness_Offset", Range(-1, 1)) = 0
        _Fresnel_Multiplier ("Fresnel_Multiplier", Range(0, 2)) = 0
        _Use_WS_Position ("Use_WS_Position", Range(0, 1)) = 1
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
            //#define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _Metallic;
            uniform sampler2D _Texture_Normal; uniform float4 _Texture_Normal_ST;
            uniform sampler2D _Texture_Masks; uniform float4 _Texture_Masks_ST;
            uniform float4 _Color;
            uniform float _Color_Multiplier;
            uniform float _Roughness_Offset;
            uniform float _Fresnel_Multiplier;
            uniform float _Use_WS_Position;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
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
                float3 _Texture_Normal_var = UnpackNormal(tex2D(_Texture_Normal,TRANSFORM_TEX(i.uv0, _Texture_Normal)));
                float3 normalLocal = _Texture_Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _Texture_Masks_var = tex2D(_Texture_Masks,TRANSFORM_TEX(i.uv0, _Texture_Masks));
                float gloss = 1.0 - saturate((((0.5-_Texture_Masks_var.b)*0.5)+_Roughness_Offset)); // Convert roughness to gloss
                float perceptualRoughness = saturate((((0.5-_Texture_Masks_var.b)*0.5)+_Roughness_Offset));
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularAO = _Texture_Masks_var.r;
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float node_6099 = 25.0;
                float node_9993 = (node_6099-distance(i.posWorld.rgb,float3(0,0,0)));
                float node_3156 = saturate((node_9993/node_6099));
                float3 node_5377 = (_Color.rgb*lerp(1.0,(node_3156+0.5),_Use_WS_Position)*((0.25*_Texture_Masks_var.g)+0.1)*_Color_Multiplier);
                float3 diffuseColor = node_5377; // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular) * specularAO;
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float3 forwardLight = max(0.0, NdotL );
                float3 backLight = max(0.0, -NdotL ) * float3(_Texture_Masks_var.g,_Texture_Masks_var.g,_Texture_Masks_var.g);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 NdotLWrap = max(0,NdotL);
                float nlPow5 = Pow5(1-NdotLWrap);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((forwardLight+backLight) + ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL)) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                indirectDiffuse *= _Texture_Masks_var.r; // Diffuse AO
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = ((1.0-max(0,dot(normalDirection, viewDirection)))*_Fresnel_Multiplier*node_5377);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
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
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _Metallic;
            uniform sampler2D _Texture_Normal; uniform float4 _Texture_Normal_ST;
            uniform sampler2D _Texture_Masks; uniform float4 _Texture_Masks_ST;
            uniform float4 _Color;
            uniform float _Color_Multiplier;
            uniform float _Roughness_Offset;
            uniform float _Fresnel_Multiplier;
            uniform float _Use_WS_Position;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
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
                float3 _Texture_Normal_var = UnpackNormal(tex2D(_Texture_Normal,TRANSFORM_TEX(i.uv0, _Texture_Normal)));
                float3 normalLocal = _Texture_Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
				UNITY_LIGHT_ATTENUATION(attenuation, i, i.posWorld.xyz)
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float4 _Texture_Masks_var = tex2D(_Texture_Masks,TRANSFORM_TEX(i.uv0, _Texture_Masks));
                float gloss = 1.0 - saturate((((0.5-_Texture_Masks_var.b)*0.5)+_Roughness_Offset)); // Convert roughness to gloss
                float perceptualRoughness = saturate((((0.5-_Texture_Masks_var.b)*0.5)+_Roughness_Offset));
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float3 specularColor = _Metallic;
                float specularMonochrome;
                float node_6099 = 25.0;
                float node_9993 = (node_6099-distance(i.posWorld.rgb,float3(0,0,0)));
                float node_3156 = saturate((node_9993/node_6099));
                float3 node_5377 = (_Color.rgb*lerp(1.0,(node_3156+0.5),_Use_WS_Position)*((0.25*_Texture_Masks_var.g)+0.1)*_Color_Multiplier);
                float3 diffuseColor = node_5377; // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float3 forwardLight = max(0.0, NdotL );
                float3 backLight = max(0.0, -NdotL ) * float3(_Texture_Masks_var.g,_Texture_Masks_var.g,_Texture_Masks_var.g);
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 NdotLWrap = max(0,NdotL);
                float nlPow5 = Pow5(1-NdotLWrap);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((forwardLight+backLight) + ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL)) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _Metallic;
            uniform sampler2D _Texture_Masks; uniform float4 _Texture_Masks_ST;
            uniform float4 _Color;
            uniform float _Color_Multiplier;
            uniform float _Roughness_Offset;
            uniform float _Fresnel_Multiplier;
            uniform float _Use_WS_Position;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float node_6099 = 25.0;
                float node_9993 = (node_6099-distance(i.posWorld.rgb,float3(0,0,0)));
                float node_3156 = saturate((node_9993/node_6099));
                float4 _Texture_Masks_var = tex2D(_Texture_Masks,TRANSFORM_TEX(i.uv0, _Texture_Masks));
                float3 node_5377 = (_Color.rgb*lerp(1.0,(node_3156+0.5),_Use_WS_Position)*((0.25*_Texture_Masks_var.g)+0.1)*_Color_Multiplier);
                o.Emission = ((1.0-max(0,dot(normalDirection, viewDirection)))*_Fresnel_Multiplier*node_5377);
                
                float3 diffColor = node_5377;
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic, specColor, specularMonochrome );
                float roughness = saturate((((0.5-_Texture_Masks_var.b)*0.5)+_Roughness_Offset));
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
